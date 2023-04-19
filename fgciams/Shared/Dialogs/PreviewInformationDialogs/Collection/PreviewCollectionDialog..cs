namespace fgciams.Shared.Dialogs.PreviewInformationDialogs.Collection
{
    public class PreviewCollectionBase : ComponentBase
    {
        #region Services Injection
        [Inject] protected ISnackbar SnackbarService { get; set; } = default!;
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
        [Inject] protected IDialogService DialogService { get; set; } = default!;
        #endregion
        #region Properties
        protected bool dataFetched;
        [CascadingParameter] MudDialogInstance MudDialog { get; set; } = new();
        [Parameter] public CollectionModel Collection { get; set; } = new();
        [Parameter] public string DialogTitle { get; set; } = string.Empty;
        [Parameter] public string CancelText { get; set; } = string.Empty;
        [Parameter] public string SubmitText { get; set; } = string.Empty;
        [Parameter] public string IconString { get; set; } = string.Empty;
        [Parameter] public string ContentText { get; set; } = string.Empty;
        [Parameter] public bool IsFAIcon { get; set; }
        protected static Enums.ActionMode actionMode;
        #endregion

        protected override async Task OnInitializedAsync()
        {
            while(GlobalClassList.accountingStatusList == null)
                await Task.Delay(1);
            if (Collection != null)
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

        protected async Task EditCollection(CollectionModel collection)
        {
            if(CheckRestriction())
            {
                var parameters = new DialogParameters();
                GlobalClass.collection = Collection;
                string dialogTitle = GlobalClass.collection.Id != 0 ? "Edit Collection" : "Add Collection";
                string buttonText = GlobalClass.collection.Id != 0 ? "Update" : "Add";
                Color color = GlobalClass.collection.Id != 0 ? Color.Info : Color.Success;
                parameters.Add("color", color);
                parameters.Add("dialogTitle", dialogTitle);
                parameters.Add("buttonText", buttonText);
                parameters.Add("currentAction", actionMode);
                var options = new DialogOptions() { CloseButton = false, MaxWidth = MaxWidth.Large, FullWidth = false, NoHeader = false, DisableBackdropClick = false };
                var resultDialog = await DialogService.Show<Shared.Dialogs.CollectionDialogs.CollectionDialog>("", parameters, options).Result;
                if (resultDialog.Canceled)
                    Extensions.ShowAlertV2("Action cancelled.", Variant.Filled, SnackbarService, Severity.Normal, Icons.Material.Filled.Cancel, Defaults.Classes.Position.BottomCenter);
                else
                    Submit();
            }
        }

        protected AccountingStatusModel AcctgStatus(long statusId)
        {
            return GlobalClassList.accountingStatusList.Where( acctg => acctg.Id == statusId).FirstOrDefault()?? new();
        }

        protected bool CheckRestriction()
        {
            if (!Common.Privileges.IsPrivilegeModule(Enums.AISModules.CollectionEntry))
            {
                string action = actionMode == Enums.ActionMode.Update ? "edit" : "create";
                Extensions.ShowAlert(String.Format("Account has been restricted to {0} collection.", action), Variant.Filled, SnackbarService, Severity.Error);
                return false;
            }
            else
                return true;
        }
    }
}