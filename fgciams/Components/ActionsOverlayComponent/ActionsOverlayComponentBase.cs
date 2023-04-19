namespace fgciams.Components.ActionsOverlayComponent
{
    public class ActionsOverlayComponentBase : ComponentBase
    {
        #region Properties
        [Parameter] public bool IsOverlayVisible { get; set; }
        [Parameter] public Enums.ActionMode ActionMode { get; set; }
        [Parameter] public string ModuleName { get; set; } = string.Empty;
        [Parameter] public int ProgressValue { get; set; }
        protected string actionString = string.Empty;
       
        #endregion

        protected override void OnInitialized() => actionString = Extensions.GetActionString(ActionMode, ModuleName);
        
    }
}