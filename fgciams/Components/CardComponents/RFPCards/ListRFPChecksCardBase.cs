using fgciams.domain.clsCheck;

namespace fgciams.Components.CardComponents.RFPCards
{
    public class ListRFPChecksCardBase : ComponentBase
    {
        #region Service Injection
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected ISnackbar SnackbarService { get; set; } = default!;
        #endregion
        #region Properties
        [Parameter] public EventCallback ClosePopup { get; set; }
        [Parameter] public List<CheckModel> CheckList { get; set; } = new();
        #endregion
        protected async Task Close() => await ClosePopup.InvokeAsync();

        protected async Task CopyTextToClipboard(string text) => await Extensions.CopyTextToClipboard(text, SnackbarService, JSRuntime);
    }
}