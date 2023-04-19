namespace fgciams.Pages.PrintPages
{
    public class PettyCashPrintBase : ComponentBase
    {
        #region Inject Services
        [Inject] protected IPettyCashService PettyCashService { get; set; } = default!;
        [Inject] protected IDialogService DialogService { get; set; } = default!;
        [Inject] protected ISnackbar SnackbarService { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
        #endregion

        #region Properties
        protected PettyCashModel returnedModel { get; set; } = new();
        protected string pdfReport = string.Empty;
        protected bool isSaved, _processing, dataFetched, _disposed;
        protected int progressValue;
        protected Enums.ActionMode actionMode = new();
        #endregion

        protected override async Task OnInitializedAsync()
        {
            GlobalClass.pageTitle = "Petty Cash Report";
            Task t = LoadPettyCashReport(GlobalClass.pettyCashForPrint);
            await t;
            if (t.Status == TaskStatus.RanToCompletion)
                CompletedFetch();
            if (GlobalClass.pettyCashForPrint == null)
                ToList();
        }

        protected void CompletedFetch()
        {
            dataFetched = true;
            StateHasChanged();
        }

        protected async Task LoadPettyCashReport(PettyCashModel petty)
        {
            var reportResult = PettyCashService.GetPettyCashReport(petty);
            await reportResult;
            if (reportResult != null)
                pdfReport = reportResult.Result;
        }

        protected async Task Prompt()
        {
            var parameters = new DialogParameters();
            string contentText = " petty cash";
            string dialogTitle = PettyCashEntry.currActionMode + contentText;
            parameters.Add("contentText", contentText);
            parameters.Add("dialogTitle", dialogTitle);
            parameters.Add("actionMode", PettyCashEntry.currActionMode);
            parameters.Add("controlNumber", GlobalClass.pettyCashForPrint.ControlNumber);
            var options = new DialogOptions()
            {
                CloseButton = false,
                MaxWidth = MaxWidth.ExtraSmall,
                FullWidth = true,
                NoHeader =  false,
                DisableBackdropClick = true
            };
            var resultDialog = await DialogService.Show<Shared.Dialogs.GenericPromptDialogs.GenericPrompt>(dialogTitle, parameters, options).Result;
            if (!resultDialog.Canceled)
            {
                _processing = true;
                actionMode = (GlobalClass.pettyCashForPrint.Id == 0 ? Enums.ActionMode.Create : Enums.ActionMode.Update);
                StartProgressValue();
                var savedPettyCash = new PettyCashModel();
                Task<PettyCashModel> pettyCashTask = (GlobalClass.pettyCashForPrint.Id == 0 ? AddPettyCash() : UpdatePettyCash());
                await pettyCashTask;
                if (pettyCashTask.Status == TaskStatus.RanToCompletion)
                {
                    savedPettyCash = pettyCashTask.Result;
                    Task loadReport = LoadPettyCashReport(savedPettyCash);
                    await loadReport;
                    if (loadReport.Status == TaskStatus.RanToCompletion)
                    {
                        _processing = false;
                        isSaved = true;
                        await InitializeSignalR(savedPettyCash);
                        Dispose();
                        GlobalClass.pettyCash = new();
                        StateHasChanged();
                    }
                    else
                        ShowErrorAlert("Code: Loading petty cash report endpoint.");
                }
                else
                    ShowErrorAlert("Code: Prompt method error.");
            }
        }

        private async Task<PettyCashModel> AddPettyCash()
        {
            var response = await PettyCashService.AddPettyCash(GlobalClass.pettyCashForPrint, GlobalClass.token);
            if (response != null)
            {
                Extensions.ShowAlert("Petty cash successfully saved.", Variant.Filled, SnackbarService, Severity.Success);
                return response;
            }
            else
            {
                ShowErrorAlert("Code: Petty Cash Add endpoint.");
                return new();
            }
        }

        private async Task<PettyCashModel> UpdatePettyCash()
        {
            var response = await PettyCashService.UpdatePettyCash(GlobalClass.pettyCashForPrint, GlobalClass.token);
            if (response != null)
            {
                Extensions.ShowAlert("Petty cash successfully updated.", Variant.Filled, SnackbarService, Severity.Info);
                return response;
            }
            else
            {
                ShowErrorAlert("Code: Petty Cash Update endpoint.");
                return new();
            }
        }

        protected async Task InitializeSignalR(PettyCashModel pettyCash)
        {
            if (GlobalVariable.AMSHubConnection != null)
            {
                if (GlobalClass.pettyCashForPrint.Id == 0)
                {
                    Task signalRTask = GlobalVariable.AMSHubConnection.InvokeAsync("SavePettyCash", pettyCash);
                    await signalRTask;
                    if (signalRTask.Status == TaskStatus.RanToCompletion)
                    {
                        NotificationModel notification = new();
                        notification.SenderId = GlobalClass.currentUserAccount.EmployeeId;
                        notification.StatusAction = Enums.ActionMode.Create;
                        notification.ModuleName = "Petty Cash";
                        notification.ControlNumber = pettyCash.ControlNumber;
                        notification.ApproverId = pettyCash.ApprovedById;
                        notification.DateNotify = DateTime.Now;
                        await Extensions.SendNotification(notification); 
                    }
                }
                else
                    await GlobalVariable.AMSHubConnection.InvokeAsync("SavePettyCash", pettyCash);
            }
            else
                ShowErrorAlert("Code: SignalR");
        }

        protected async void StartProgressValue()
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
            if(isSaved)
                ToList();
            else
            {
                GlobalClass.pettyCash = GlobalClass.pettyCashForPrint;
                NavigationManager.NavigateTo($"/petty-cash");
            }
        }
        protected void Dispose() => _disposed = true;
        protected void ToList() => NavigationManager.NavigateTo($"/petty-cash/list");
        protected void ShowErrorAlert(string message) 
        {
            Dispose();
            Extensions.ShowAlert($"An error has occurred, Please contact IT Administrator. {message}", Variant.Filled, SnackbarService, Severity.Error);
        }
    }
}