namespace fgciams.Components.CardComponents.VoucherCards
{
    public class ListVoucherCardBase : ComponentBase
    {
        #region Service Injection
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected ISnackbar SnackbarService { get; set; } = default!;
        #endregion
        #region Properties
        [Parameter] public EventCallback ClosePopup { get; set; }
        [CascadingParameter] protected AppStoreState ApplicationState { get; set; } = new();
        #endregion
        protected async Task Close() => await ClosePopup.InvokeAsync();
        
        protected async Task CopyAllVoucherNo()
        {
            string vouchersString = string.Empty;
            foreach (var item in ApplicationState.CheckVoucherList)
                vouchersString += item.VoucherNumber + ", ";
            vouchersString = vouchersString.Remove(vouchersString.Length - 2);
            await CopyTextToClipboard(vouchersString);
        }

        protected async Task CopyTextToClipboard(string text) => await Extensions.CopyTextToClipboard(text, SnackbarService, JSRuntime);
    }
}