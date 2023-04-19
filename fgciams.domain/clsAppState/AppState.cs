namespace fgciams.domain.clsAppstate
{
    public class ApplicationState
    {
        public bool IsDirty { get; set; }
        public bool _checkListCompState { get; set; }
        public bool DrawerState { get; set; }
        public string AppsStateStr = string.Empty;
        public event Action? OnChange;
        public async Task UpdateMainLayoutComponent(bool state)
        {
            IsDirty = state;
            await NotifyStateChangedAsync();
        }
        public async Task UpdateCheckListCompState(bool state)
        {
            _checkListCompState = state;
            await NotifyStateChangedAsync();
        }
        public void CLCompState(bool state)
        {
            _checkListCompState = state;
            NotifyStateChanged();
        }
        public void UpdateLayoutDrawer(bool state)
        {
            DrawerState = state;
            NotifyStateChanged();   
        }
        private async Task NotifyStateChangedAsync() => await Task.Run(() => OnChange?.Invoke());
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}