namespace fgciams.Pages.PrintPages
{
    public class LiquidationPrintBase : ComponentBase
    {
        #region Inject Services
        [Inject] protected ILiquidationService LiquidationService { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
        [Inject] protected IConfiguration config { get; set; } = default!;
        [Inject] protected IDialogService DialogService { get; set; } = default!;
        [Inject] protected ISnackbar SnackbarService { get; set; } = default!;
        [Inject] protected IPettyCashService PettyCashService { get; set; } = default!;
        #endregion
        #region Properties
        protected string pdfReport = string.Empty;
        protected bool isSaved, _processing;
        private bool _disposed, dataFetched;
        protected Enums.ActionMode actionMode = new();
        protected int progressValue;
        #endregion

        protected override async Task OnInitializedAsync()
        {
            GlobalClass.pageTitle = "liquidation report";
            Task t = LoadLiquidationReport(GlobalClass.forPrintingOrSaveLiquidation);
            await t;
            if (t.Status == TaskStatus.RanToCompletion)
                 CompletedFetch();
            if (GlobalClass.forPrintingOrSaveLiquidation == null)
                ToList();
        }

        protected void CompletedFetch()
        {
            dataFetched = true;
            StateHasChanged();
        }

        private async Task LoadLiquidationReport(LiquidationModel liquidation)
        {
            var reportResult = LiquidationService.PrintSaveLiquidation(liquidation);
            await reportResult;
            if (reportResult.Status == TaskStatus.RanToCompletion && reportResult != null)
            {
                pdfReport = await LiquidationService.PrintSaveLiquidation(liquidation);
                pdfReport += "#toolbar=0";
            }
        }

        protected async Task Prompt()
        {
            var liquidation = new LiquidationModel();
            var parameters = new DialogParameters();
            string contentText = "Liquidation";
            string dialogTitle = GlobalClass.forPrintingOrSaveLiquidation.Id == 0 ? "Create " + contentText : "Update " + contentText;
            parameters.Add("contentText", contentText);
            parameters.Add("dialogTitle", dialogTitle);
            parameters.Add("controlNumber", GlobalClass.forPrintingOrSaveLiquidation.ControlNumber);
            parameters.Add("actionMode", GlobalClass.forPrintingOrSaveLiquidation.Id == 0 ? Enums.ActionMode.Create : Enums.ActionMode.Update);
            var options = new DialogOptions() 
            { 
                CloseButton = false, 
                MaxWidth = MaxWidth.ExtraSmall, 
                FullWidth = true, 
                NoHeader = false, 
                DisableBackdropClick = true 
            };
            var resultDialog = await DialogService.Show<Shared.Dialogs.GenericPromptDialogs.GenericPrompt>(dialogTitle, parameters, options).Result;
            if (!resultDialog.Canceled)
            {
                _processing = true;
                actionMode = (GlobalClass.forPrintingOrSaveLiquidation.Id == 0 ? Enums.ActionMode.Create : Enums.ActionMode.Update);
                StartProgressValue();
                var resultLiquidation = new LiquidationModel();
                Task<LiquidationModel> liquidationTask = (GlobalClass.forPrintingOrSaveLiquidation.Id == 0 ? AddLiquidation() : UpdateLiquidation());
                await liquidationTask;
                if (liquidationTask.Status == TaskStatus.RanToCompletion)
                {
                    resultLiquidation = liquidationTask.Result;
                    Task loadReport = LoadLiquidationReport(resultLiquidation);
                    await loadReport;
                    if (loadReport.Status == TaskStatus.RanToCompletion)
                    {
                        _processing = false;
                        isSaved = true;
                        await InitializeSignalR(resultLiquidation);
                        Dispose();
                        StateHasChanged();
                    }
                    else
                        ShowErrorAlert("Code: Loading liquidation report method.");
                }
                else
                    ShowErrorAlert("Code: Prompt method error.");
              
            }
            _processing = false;
        }
        protected async Task InitializeSignalR(LiquidationModel liquidation)
        {
            if (GlobalVariable.AMSHubConnection != null)
            {
                if(GlobalClass.forPrintingOrSaveLiquidation.Id == 0) 
                {
                    await Task.Run( async ()=> await GlobalVariable.AMSHubConnection.InvokeAsync("SaveLiquidation", liquidation).
                        ContinueWith( async(t) => 
                        {   
                            if(t.Status == TaskStatus.RanToCompletion) 
                            {  
                                NotificationModel notification = new();
                                notification.SenderId = GlobalClass.currentUserAccount.EmployeeId;
                                notification.StatusAction = Enums.ActionMode.Create;
                                notification.ModuleName = "Liquidation";
                                notification.ControlNumber = liquidation.ControlNumber;
                                notification.ApproverId = liquidation.ApprovedById;
                                notification.DateNotify = DateTime.Now;
                                await Extensions.SendNotification(notification); 
                            }
                        }));
                } 
                else 
                {
                    liquidation.LiquidationDetails.Clear();
                    await GlobalVariable.AMSHubConnection.InvokeAsync("SaveLiquidation", liquidation);
                }
            }
        }
        private async Task<LiquidationModel> AddLiquidation()
        {
            Task<LiquidationModel> response = LiquidationService.AddLiquidation(GlobalClass.forPrintingOrSaveLiquidation, GlobalClass.token);
            await response;
            if (response.Status == TaskStatus.RanToCompletion && response.Result != null)
            {
                Extensions.ShowAlert("Liquidation successfully saved.", Variant.Filled, SnackbarService, Severity.Success);
                return response.Result;
            }
            else
            {
                ShowErrorAlert("Code: Liquidaton Add endpoint.");
                return new();
            }

        }

        private async Task<LiquidationModel> UpdateLiquidation()
        {
            Task<LiquidationModel> response = LiquidationService.UpdateLiquidation(GlobalClass.forPrintingOrSaveLiquidation, GlobalClass.token);
            await response;

            var acctgStatusPCR = GlobalClassList.accountingStatusList.Where(x => x.StatusEnumCategoryId == Enums.AccountingStatusEnumCategory.PCR).FirstOrDefault();
            var acctgStatusPCL = GlobalClassList.accountingStatusList.Where(x => x.StatusEnumCategoryId == Enums.AccountingStatusEnumCategory.PCL).FirstOrDefault();

            if (response.Status == TaskStatus.RanToCompletion && response.Result != null)
            {
                GlobalClass.forPrintingOrSaveLiquidation.RemovedLiquidationDetails.ForEach( async (lDetails) => {
                    PettyCashModel newDetails = new();
                    if(lDetails.Id != 0 && !GlobalClass.forPrintingOrSaveLiquidation.LiquidationDetails.Any( x => x.PettyCashId == lDetails.PettyCashId))
                    {
                        newDetails = (await PettyCashService.LoadPettyCashList(new FilterParameter()
                            {
                                isActive = true, 
                                PageNo = 0, 
                                PageSize = 15, 
                                IsControlNumber = true,
                                ControlNumber = lDetails.ControlNumber
                            }, GlobalClass.token)).LastOrDefault()?? new();//since query using LIKE operator and descending order
                        newDetails.Id = lDetails.PettyCashId;
                        newDetails.Activity = "Removed from liquidation.";
                        newDetails.UserId = GlobalClass.currentUserAccount.EmployeeId;
                        //Status Received
                        newDetails.StatusName = acctgStatusPCR.StatusName;
                        newDetails.StatusId = (Int64)acctgStatusPCR.Id;
                        newDetails.StatusEnumCategoryId = acctgStatusPCR.StatusEnumCategoryId;
                        await PettyCashService.UpdatePettyCash(newDetails,GlobalClass.token);
                    }
                });
                GlobalClass.forPrintingOrSaveLiquidation.LiquidationDetails.ForEach( async (lDetails) => {
                    PettyCashModel newDetails = new();
                    if(lDetails.StatusEnumCategoryId != acctgStatusPCL.StatusEnumCategoryId)
                    {
                        Task<PettyCashModel> t = GetPettyCash(lDetails.ControlNumber);
                        await t;
                        if(t.Status == TaskStatus.RanToCompletion)
                        {
                            newDetails = t.Result;
                            newDetails.Id = lDetails.PettyCashId;
                            newDetails.Activity = "Pettycash Liquidated.";
                            newDetails.UserId = GlobalClass.currentUserAccount.EmployeeId;
                            //Status Received
                            newDetails.StatusName = acctgStatusPCL.StatusName;
                            newDetails.StatusId = (Int64)acctgStatusPCL.Id;
                            newDetails.StatusEnumCategoryId = acctgStatusPCL.StatusEnumCategoryId;
                            await PettyCashService.UpdatePettyCash(newDetails,GlobalClass.token);
                        }
                    }
                });
                
            Extensions.ShowAlert("Liquidation updated successfully.", Variant.Filled, SnackbarService, Severity.Success);
            return response.Result;
            }
            else
            {
                ShowErrorAlert("Code: Liquidaton update endpoint.");
                return new();
            }
        }
        private async Task<PettyCashModel> GetPettyCash(string ControlNumber)
        {
            return (await PettyCashService.LoadPettyCashList(new FilterParameter()
            {
                isActive = true, 
                PageNo = 0, 
                PageSize = 15, 
                IsControlNumber = true,
                ControlNumber = ControlNumber
            }, GlobalClass.token)).LastOrDefault()?? new();//since query using LIKE operator and descending order
        }
        private async void StartProgressValue()
        {
            progressValue = 0;
            do
            {
                if (_disposed)
                    return;
                progressValue += 4;
                StateHasChanged();
                await Task.Delay(500);

            } while (progressValue < 100);

		    StartProgressValue();
        }

        protected void Back()
        {
            if(!isSaved)
            {
                GlobalClass.liquidation = GlobalClass.forPrintingOrSaveLiquidation;
                NavigationManager.NavigateTo($"/liquidation");  
            }
            else
            {
                NavigationManager.NavigateTo($"/liquidation/list");
                GlobalClass.forPrintingOrSaveLiquidation = default!;
            }
        }
        private void Dispose() => _disposed = true;
        private void ToList() => NavigationManager.NavigateTo($"/liquidation/list");
        protected void ShowErrorAlert(string message) 
        {
            Dispose();
            Extensions.ShowAlert($"An error has occurred, Please contact IT Administrator. {message}", Variant.Filled, SnackbarService, Severity.Error);
        }
    }
}