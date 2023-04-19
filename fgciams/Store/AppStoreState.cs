namespace fgciams.Store
{
    public class AppStoreState
    {
        public event Action? OnChange;
        public bool IsNotificationSilent;
        public List<CheckVoucherModel> CheckVoucherList = new();
        public List<NotificationModel> Notifications = new();
        public List<UserAccount> TemporaryEmployeeList = new();
        private async Task NotifyStateChangedAsync() => await Task.Run(() => OnChange?.Invoke());
        private void NotifyStateChanged() => OnChange?.Invoke();
        public async Task UpdateStoreState() =>  await NotifyStateChangedAsync();
    }
}