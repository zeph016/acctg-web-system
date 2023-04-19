namespace fgciams.Components.EmployeeCard
{
    public class EmployeeCardTheadComponentBase : ComponentBase
    {
        #region Inject Service
        #endregion
        #region Properties
        [Parameter] public UserAccount Employee { get; set; } = new();
        [Parameter] public bool IsSelected { get; set; }
        [Parameter] public bool IsResult { get; set; }
        #endregion
    }
}