namespace fgciams.Pages.ModulePages.ReportPage
{
    public class VoucherReportBase : ComponentBase
    {
        #region Inject
        [Inject] IVoucherService VoucherService { get; set; } = default!;
        [Inject] IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] ISnackbar SnackbarService { get ;set ; } = default!;
        #endregion
        #region properties
        protected bool IsDataFetch = false;
        protected bool  openFilter = false;
        protected string PDFContent = string.Empty;
        private byte[] ByteFile = new byte[]{};
        private FilterParameter filterParameter =  new();
        private FilterParameter reportParameter = new();
        #endregion
        protected override async Task OnInitializedAsync()
        {
            GlobalClass.pageTitle = "Voucher Report";
            Task t = GetReport();
            await t;
            if(t.Status == TaskStatus.RanToCompletion)
            {
                CompletedFetch();
            }   
        }
        private void CompletedFetch()
        {
            IsDataFetch = true;
            StateHasChanged();
        }
        public async Task FilterTable()
        {
            filterParameter = GlobalVariable.filterParameter;
            filterParameter.Token = GlobalClass.token;
            Task t = GetReport();
            await t;
            if(t.Status == TaskStatus.RanToCompletion)
            {
                reportParameter = filterParameter;
                StateHasChanged();
            }
        }
        public async Task GetReport()
        {
            GlobalVariable.FileDownloading = true;
            if(GlobalVariable.FileType == Enums.FileType.PDF)
            {
                Task<string> t = VoucherService.GenerateNewVoucherReport(filterParameter, GlobalClass.token);
                await t;
                if(t.Status == TaskStatus.RanToCompletion)
                {
                    PDFContent = t.Result;
                } else {
                    Extensions.ShowAlert("There was a problem while exporting your file", Variant.Filled, SnackbarService, Severity.Error);
                }
            } else {
                Task<byte[]> t1 = VoucherService.VoucherReportGetExcel(filterParameter, GlobalClass.token);
                await t1;
                if(t1.Status == TaskStatus.RanToCompletion)
                {
                    ByteFile = t1.Result ;
                    await DownloadExcel();
                }  else {
                    Extensions.ShowAlert("There was a problem while exporting your file", Variant.Filled, SnackbarService, Severity.Error);
                }
            }
            GlobalVariable.FileDownloading = false;
        }
        private string Base64String()
        {
            return Convert.ToBase64String(ByteFile);
        }
        private Stream GetFileStream()
        {
            return new MemoryStream(ByteFile);
        }
        public async Task DownloadExcel()
        {
            using var streamRef = new DotNetStreamReference(GetFileStream(), true);
            await JSRuntime.InvokeVoidAsync("downloadFileFromStream", "Voucher.xlsx", streamRef);
        }
        public async Task Export() =>  await JSRuntime.InvokeVoidAsync("exportTableToExcel", "journalTable","");
    }
}