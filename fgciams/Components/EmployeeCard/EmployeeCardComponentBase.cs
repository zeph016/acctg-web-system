namespace fgciams.Components.EmployeeCard
{
    public class EmployeeCardComponentBase : ComponentBase
    {
        #region Inject Services
        [Inject] protected IGlobalService GlobalService { get; set; } = default!;
        [Inject] protected IJSRuntime JSRuntime { get; set; } = default!;
        [Inject] protected ISnackbar SnackbarService { get; set; } = default!;
        #endregion
        #region Properties
        [CascadingParameter] public AppStoreState ApplicationState { get; set; } = new();
        [Parameter] public UserAccount Employee { get; set; } = new();
        [Parameter] public bool isITEmployee { get; set; }
        [Parameter] public string employeeName { get; set; } = string.Empty;
        [Parameter] public long EmployeeId { get; set; }
        [Parameter] public long? employeeITId { get; set; }
        protected bool dataFetched;
        protected UserAccount employeeDetails = new();
        #endregion

        protected override async Task OnInitializedAsync()
        {
            Task t = GetEmployeeDetails();
            await t;
            if (t.Status == TaskStatus.RanToCompletion)
                CompeletedFetch();
            
            Console.WriteLine(ApplicationState.TemporaryEmployeeList.Count());
        }
        private void CompeletedFetch()
        {
            dataFetched = true;
            StateHasChanged();
        }
        private async Task GetEmployeeDetails()
        {
            var response = ApplicationState.TemporaryEmployeeList.Where(x=>x.EmployeeId == EmployeeId).FirstOrDefault();
            if (response != null)
                employeeDetails = response;
            else
                response = await GlobalService.GetEmployeeById(EmployeeId, GlobalClass.token);
                if (response != null)
                {
                    ApplicationState.TemporaryEmployeeList.Add(response);
                    await ApplicationState.UpdateStoreState();
                    employeeDetails = response;
                }
        }
    }
}