namespace fgciams.Shared.Dialogs.PreviewInformationDialogs.Check
{
    public class PreviewDebitDialogBase : ComponentBase 
    {
        #region Services Injection
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected ISnackbar SnackbarService { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManger { get; set; } = default!;
        #endregion
        #region Properties
        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = new();
        [Parameter] public DebitModel Debit { get; set; } = new();
        [Parameter] public string DialogTitle { get; set; } = string.Empty; 
        [Parameter] public string CancelText { get; set; } = string.Empty;
        [Parameter] public string IconString { get; set; } = string.Empty;
        protected bool dataFetched;
        #endregion

        protected override void OnInitialized()
        {
            if (Debit.Id != 0)
                CompletedFetch();
        }
        protected void CompletedFetch()
        {
            dataFetched = true;
            StateHasChanged();
        }
        protected async Task CopyTextToClipboard(string stringToCopy) => await Extensions.CopyTextToClipboard(stringToCopy, SnackbarService, JSRuntime);
        protected void Cancel() => MudDialog.Cancel();
        protected void EditDebit(DebitModel debit)
        {
            DebitEntry.currentActionMode = Enums.ActionMode.Update;
            GlobalClass.debit = debit;
            NavigationManger.NavigateTo($"/debit");
        }
    }
}