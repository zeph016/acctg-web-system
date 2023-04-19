namespace fgciams.Pages.ModulePages.ReportPage
{
    public class SOABase : ComponentBase
    {
        #region Inject
        [Inject] IVoucherService VoucherService { get; set; } = default!;
        [Inject] IJSRuntime JSRuntime { get; set; } = default!;
        #endregion
        #region properties
        protected bool IsDataFetch = false;
        protected bool  openFilter = false;
        protected string PDFContent = string.Empty;
        private FilterParameter filterParameter =  new();
        #endregion
        protected override void OnInitialized()
        {
            GlobalClass.pageTitle = "Statement of Account";
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            //Default param first load avoid overloaded data
            if(firstRender)
            {
                filterParameter.IsDate = true;
                filterParameter.DateFrom = DateTime.Now;
                filterParameter.DateTo = DateTime.Now;
                await InitilizedData();
            }
        }
        private async Task InitilizedData()
        {
            Task t = VoucheDetailList();
            await t;
            if(t.Status == TaskStatus.RanToCompletion)
            {
                Task t1 = GetReport();
                await t1;
                if(t1.Status == TaskStatus.RanToCompletion)
                {
                    StateHasChanged();
                }
                
            }   
            CompletedFetch();
        }
        private void CompletedFetch()
        {
            IsDataFetch = true;
            StateHasChanged();
        }
        public async Task VoucheDetailList()
        {
            GlobalClassList.voucherDetailList = await VoucherService.VoucherDetailSOAList(filterParameter , GlobalClass.token);
        }
        public async Task FilterTable()
        {
            filterParameter = GlobalVariable.filterParameter;
            filterParameter.Token = GlobalClass.token;
            await InitilizedData();

        }
        public async Task GetReport()
        {
            //For Report
            (GlobalClassList.voucherDetailList.FirstOrDefault()?? new()).ReportDate = GetDateString();
            (GlobalClassList.voucherDetailList.FirstOrDefault()?? new()).ExpenseName = GetExpense();
            (GlobalClassList.voucherDetailList.FirstOrDefault()?? new()).ReportHeader = GetExpense();

            PDFContent = await VoucherService.GenerateVoucherSOA(GlobalClassList.voucherDetailList, GlobalClass.token);
        }
        public async Task Export() =>  await JSRuntime.InvokeVoidAsync("exportTableToExcel", "journalTable","");
        private string GetDateString()
        {
            if(filterParameter.IsDate)
                return String.Format("{0} - {1}",filterParameter.DateFrom.ToString("MM/dd/yyyy"),filterParameter.DateTo.ToString("MM/dd/yyyy"));
            else
                return DateTime.Now.ToString("MM/dd/yyyy");
        }
        private string GetExpense()
        {
            if(filterParameter.IsExpense)
                return (GlobalClassList.expenseLineList.Where( e => e.Id == filterParameter.ExpenseId).FirstOrDefault()?? new()).ExpenseName;
            else
                return string.Empty;
        }
    }
}