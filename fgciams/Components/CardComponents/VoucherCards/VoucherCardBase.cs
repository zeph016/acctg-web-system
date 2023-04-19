namespace fgciams.Components.CardComponents.VoucherCards
{
    public class VoucherCardBase : ComponentBase
    {
        #region Inject Services
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected ISnackbar SnackbarService { get; set; } = default!;
        #endregion
        #region Properties
        [Parameter] public CheckVoucherModel CheckVoucher { get; set; } = new();
        #endregion

        protected async Task CopyTextToClipboard(string ctrlNo) => await Extensions.CopyTextToClipboard(ctrlNo, SnackbarService, JSRuntime);
    }
}