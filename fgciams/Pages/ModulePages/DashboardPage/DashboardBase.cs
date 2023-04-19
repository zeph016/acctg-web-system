namespace fgciams.Pages.ModulePages.DashboardPage
{
    public class DashboardBase : ComponentBase
    {
        #region Inject Service
        [Inject] protected IRequestForPaymentService RequestForPaymentService { get; set; } = default!;
        [Inject] protected ILocalStorageService LocalStorageService { get; set; } = default!;
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        #endregion
        #region Properties
        [CascadingParameter] public AppStoreState ApplicationState { get; set; } = new();
        protected IEnumerable<RequestForPaymentModel>? pagedData;
        protected IEnumerable<RequestForPaymentModel>? rfpList;
        // private FilterParameter filterParameter = new();
        protected MudTable<RequestForPaymentModel> rfpTableVar = new MudTable<RequestForPaymentModel>();
        protected int totalRFP;
        protected bool dataFetched, rfpLoading;
        #endregion

        protected override async Task OnInitializedAsync()
        {
            GlobalClass.pageTitle = "Dashboard";
            Task t = LoadAllData();
            await t;
            if (t.Status == TaskStatus.RanToCompletion)
                CompletedFetch();
        }

        private void CompletedFetch()
        {
            dataFetched = true;

        }

        protected async Task TestButton()
        {
            ApplicationState.IsNotificationSilent = !ApplicationState.IsNotificationSilent;
            await ApplicationState.UpdateStoreState();
        }

        private async Task LoadAllData()
        {
            await LoadRFPData();
        }

        protected async Task RefreshAllData()
        {
            await rfpTableVar.ReloadServerData();
        }

        private async Task LoadRFPData()
        {
             rfpLoading = true;
            FilterParameter filterParameter = new() {
                PageSize = 15,
                PageNo = 0
            };
            rfpList= await RequestForPaymentService.LoadRequestPayment(filterParameter,
            GlobalClass.token);
        }
        protected async Task<TableData<RequestForPaymentModel>> LoadRFP(TableState tableState)
        {
            rfpLoading = true;
            FilterParameter filterParameter = new() {
                PageSize = 15,
                PageNo = 0
            };
            IEnumerable<RequestForPaymentModel> data = await RequestForPaymentService.LoadRequestPayment(filterParameter,
            GlobalClass.token);
            switch (tableState.SortLabel)
            {
                case "SortControlNumber":
                    data = data.OrderByDirection(tableState.SortDirection, x => x.Id);
                    break;
                case "SortDate":
                    data = data.OrderByDirection(tableState.SortDirection, x => x.RequestDate);
                    break;
            }
            totalRFP = data.Count();
            pagedData = data.Skip(tableState.Page * tableState.PageSize).Take(tableState.PageSize).ToArray();
            
            return new TableData<RequestForPaymentModel>()
            {
                TotalItems = totalRFP,
                Items = pagedData
            };
        }
    }
}