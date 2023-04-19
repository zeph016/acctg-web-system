namespace fgciams.Pages.PrintPages
{
    public class VoucherPrintBase : ComponentBase
    {
        #region Inject Services
        [Inject] protected IVoucherService VoucherService { get; set; } = default!;
        [Inject] protected IDialogService DialogService { get; set; } = default!;
        [Inject] protected ISnackbar SnackbarService { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
        #endregion

        #region Properties
        protected string pdfReport = string.Empty;
        protected bool isSaved, _processing, isPrint, dataFetched, _disposed;
        protected int progressValue;
        protected Enums.ActionMode actionMode = new();
        #endregion

        protected override async Task OnInitializedAsync()
        {
            GlobalClass.pageTitle = "Voucher Report";
            Task t = LoadVoucherReport();
            await t;
            if (t.Status == TaskStatus.RanToCompletion)
                CompletedFetch();
        }

        protected void CompletedFetch()
        {
            dataFetched = true;
            StateHasChanged();
        }
        protected async Task LoadVoucherReport()
        {
            var reportResult = VoucherService.GenerateLiquidationVoucherReport(GlobalClass.forPrintingOrSaveVoucher);
            await reportResult;
            if (reportResult.Status == TaskStatus.RanToCompletion)
            {
                pdfReport = reportResult.Result;
                pdfReport += "#toolbar=0";
            }
        }

        protected async Task Prompt()
        {
            var parameters = new DialogParameters();
            string contentText = "Voucher";
            string dialogTitle = GlobalClass.forPrintingOrSaveVoucher.Id == 0 ? "Create " + contentText : "Update " + contentText;
            parameters.Add("dialogTitle", dialogTitle);
            parameters.Add("actionMode", GlobalClass.forPrintingOrSaveVoucher.Id == 0 ? Enums.ActionMode.Create :
            Enums.ActionMode.Update);
            parameters.Add("contentText", contentText);
            parameters.Add("controlNumber", GlobalClass.forPrintingOrSaveVoucher.ControlNumber);
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
                StartProgressValue();
                var SavedVoucher = new VoucherModel();
                Task<VoucherModel> task = (GlobalClass.forPrintingOrSaveVoucher.Id == 0 ? AddVoucher() : UpdateVoucher());
                await task;
                if (task.Status == TaskStatus.RanToCompletion)
                {
                    SavedVoucher = task.Result;
                    SavedVoucher = AddVDetailTempId(SavedVoucher);
                    Task<string> pdfTask = GeneratePDFReport(SavedVoucher);
                    await pdfTask;
                    if (pdfTask.Status == TaskStatus.RanToCompletion)
                    {
                        pdfReport = pdfTask.Result;
                        _processing = false;
                        isSaved = true;
                        await InitializeSignalR(SavedVoucher);
                        Dispose();
                    }
                }
            }
        }

        protected async Task<VoucherModel> AddVoucher()
        {
            var response =  await VoucherService.AddVoucher(GlobalClass.forPrintingOrSaveVoucher, GlobalClass.token);
            if (response != null)
            {
                actionMode = Enums.ActionMode.Create;
                Extensions.ShowAlert("Voucher successfully saved.", Variant.Filled, SnackbarService, Severity.Success);
                return response;
            }
            else
            {
                ShowErrorAlert("Code: Voucher Add endpoint.");
                return new();
            }
        }

        protected async Task<VoucherModel> UpdateVoucher()
        {
           var response =  await VoucherService.UpdateVoucher(GlobalClass.forPrintingOrSaveVoucher, GlobalClass.token);
            if (response != null)
            {
                actionMode = Enums.ActionMode.Update;
                Extensions.ShowAlert("Voucher successfully updated.", Variant.Filled, SnackbarService, Severity.Info);
                return response;
            }
            else
            {
                ShowErrorAlert("Code: Voucher Update endpoint.");
                return new();
            }
        }

        protected async Task<string> GeneratePDFReport(VoucherModel voucher)
        {
            var response = VoucherService.GenerateLiquidationVoucherReport(voucher);
            await response;
            return response.Result;
        }

        protected VoucherModel AddVDetailTempId(VoucherModel voucher)
        {
            int count = 0;
            voucher.VoucherDetails.ForEach(vDetails =>
            {
                count++;
                vDetails.TemporaryId = count;
            });
            return voucher;
        }

        protected async Task InitializeSignalR(VoucherModel voucher)
        {
            voucher.VoucherDetails = new();
            if (GlobalVariable.AMSHubConnection != null)
            {
                if (GlobalClass.forPrintingOrSaveVoucher.Id == 0)
                {
                    Task signalRTask = GlobalVariable.AMSHubConnection.InvokeAsync("SaveVoucher", voucher);
                    await signalRTask;
                    if (signalRTask.Status == TaskStatus.RanToCompletion)
                    {
                        NotificationModel notification = new();
                        notification.SenderId = GlobalClass.currentUserAccount.EmployeeId;
                        notification.StatusAction = Enums.ActionMode.Create;
                        notification.ModuleName = "Voucher";
                        notification.ControlNumber = voucher.ControlNumber;
                        notification.ApproverId = voucher.ApprovedById;
                        notification.DateNotify = DateTime.Now;
                        await Extensions.SendNotification(notification);
                    }
                }
                else
                {
                    await GlobalVariable.AMSHubConnection.InvokeAsync("SaveVoucher", voucher);
                }
            }
            else
                ShowErrorAlert("Code: SignalR.");
        }

        protected void Back()
        {
            if (!isSaved)
            {
                isPrint = true;
                GlobalClass.voucher = GlobalClass.forPrintingOrSaveVoucher;
                NavigationManager.NavigateTo($"/voucher");
            }
            else
            {
                NavigationManager.NavigateTo($"/voucher/list");
                GlobalClass.forPrintingOrSaveVoucher = default!;
            }
            VoucherEntryPage.IsRFPRequest = false;
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
        protected void Dispose() => _disposed = true;
        protected void ShowErrorAlert(string message) 
        {
            Dispose();
            Extensions.ShowAlert($"An error has occurred, Please contact IT Administrator. {message}", Variant.Filled, SnackbarService, Severity.Error);
        }
        
    }
}