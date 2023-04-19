namespace fgciams.Components.ReportComponents
{
    public class ReportComponentBase : ComponentBase
    {
        #region Properties
        [Parameter] public EventCallback CloseReportClick { get; set; }
        [Parameter] public bool ShowReport { get; set; }
        [Parameter] public bool IsList { get; set; }
        [Parameter] public bool IsFullHeight { get; set; }
        [Parameter] public string ReportContent { get; set; } = string.Empty;
        #endregion

        protected async Task CloseReport()
        {
            ShowReport = !ShowReport;
            await CloseReportClick.InvokeAsync();
        }
    }
}