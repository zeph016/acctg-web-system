using fgciams.domain.clsEnums;

namespace fgciams.Shared.Dialogs.PreviewInformationDialogs.Check
{
    public class PreviewCheckDialogBase : ComponentBase
    {
        #region Services Injection
        [Inject] protected ISnackbar SnackbarService { get; set; } = default!;
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
        #endregion
        protected bool dataFetched, IsFormView, isViewVouchers;
        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = new();
        [Parameter] public CheckModel Check { get; set; } = new();
        [Parameter] public string DialogTitle { get; set; } = string.Empty; 
        [Parameter] public string CancelText { get; set; } = string.Empty;
        [Parameter] public string IconString { get; set; } = string.Empty;
        protected AppStoreState ApplicationState { get; set; } = new();
        protected string buttonBG = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1000);
            ApplicationState.CheckVoucherList = Check.CheckVouchers.ToList();
            CompletedFetch();
        }

        protected void CompletedFetch()
        {
            dataFetched = true;
            StateHasChanged();
        }

        protected async Task CopyTextToClipboard(string stringToCopy) => await Extensions.CopyTextToClipboard(stringToCopy, SnackbarService, JSRuntime);
        protected void Submit() => MudDialog.Close(DialogResult.Ok(true));
        protected void Cancel() => MudDialog.Cancel();
        protected string AccountingStatusName(long accountingStatusID)
        {
            return GlobalClassList.accountingStatusList
                .Where( acctg => accountingStatusID == acctg.Id)
                .Select( acctg => acctg.StatusName)
                .FirstOrDefault()?? string.Empty;
        }

        protected void EditCheck(CheckModel Check)
        {
            GlobalClass.checkModel = Check;
            CheckWriter.currentActionMode = Enums.ActionMode.Update;
            NavigationManager.NavigateTo($"/check/create");
        }
    }
}