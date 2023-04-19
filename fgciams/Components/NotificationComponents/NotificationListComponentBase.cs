namespace fgciams.Components.NotificationComponents
{
    public class NotificationListComponentBase : ComponentBase
    {
        #region Inject Service
        [Inject] protected ILocalStorageService LocalStorageService { get; set; } = default!;
        [Inject] protected NavigationManager NavigationManager { get; set; } = default!;
        #endregion
        #region Properties
        protected bool dataFetched;
        [CascadingParameter] public AppStoreState ApplicationState { get; set; } = new();
        [Parameter] public List<NotificationModel> NotificationListModel { get; set; } = new();
        [Parameter] public EventCallback NotificationClick { get; set; }
        [Parameter] public EventCallback CallbackStateHasChanged { get; set; }
        protected List<NotificationModel> notificationList { get; set; } = new();
        protected Enums.NotificationViewType viewType { get; set; } = new();
        #endregion
        protected override async Task OnInitializedAsync()
        {
            await FilterNotificationList(Enums.NotificationViewType.All);
        }

        private void CompletedFetch()
        {
            dataFetched = true;
            StateHasChanged();
        }
        protected async Task FilterNotificationList(Enums.NotificationViewType notifViewType)
        {
            viewType = notifViewType;
            var list = await GetNotificationFromLS();
            if (list != null)
            {
                ApplicationState.Notifications = list;
                await ApplicationState.UpdateStoreState();
                await ReloadTableState();
                if (notifViewType == Enums.NotificationViewType.All)
                    notificationList = list.OrderByDescending(x => x.DateNotify).ToList();
                else if (notifViewType == Enums.NotificationViewType.Read)
                    notificationList = list.Where(x => x.IsSeen).OrderByDescending(x => x.DateNotify).ToList();
                else if (notifViewType == Enums.NotificationViewType.Unread)
                    notificationList = list.Where(x => x.IsSeen == false).OrderByDescending(x => x.DateNotify).ToList();
            }
        }

        protected async Task ReloadTableState()
        {
            dataFetched = false;
            notificationList.Clear();
            await Task.Delay(250);
            CompletedFetch();
            
        }
        protected async Task Navigate(NotificationModel mode)
        {
            await NotificationClick.InvokeAsync();
            mode.IsSeen = true;
            Extensions.NavigateToDocument(mode, NavigationManager, LocalStorageService);
        }

        protected async Task MarkAllRead()
        {
            NotificationListModel.ForEach(n => n.IsSeen = true);
            StateHasChanged();
            await Extensions.RemoveAndSetNotificationStorage(LocalStorageService);
        }

        protected async Task ClearAllNotifications() 
        {
            ApplicationState.Notifications.Clear();
            notificationList.Clear();
            await Extensions.ClearNotifications(LocalStorageService);
            await Refresh();
        }

        protected async Task RemoveNotificationFromStorage()
        {
            NotificationListModel = GlobalClassList.notificationList = new();
            StateHasChanged();
            await LocalStorageService.RemoveItemAsync("notifications");
        }

        protected async Task SetNotificationConfig()
        {
            ApplicationState.IsNotificationSilent = !ApplicationState.IsNotificationSilent;
            await Extensions.SetSilentNotification(LocalStorageService, ApplicationState.IsNotificationSilent);
            await ApplicationState.UpdateStoreState();
        }

        protected async Task UpdateSelectedNotification(string indexStr)
        {
            var list = notificationList;
            if (list != null)
            {
                var item = list.Where(x => x.TempId == indexStr).FirstOrDefault();
                if (item != null && !item.IsSeen)
                {
                    item.IsSeen = true;
                    int index = list.FindIndex(x => x.TempId == indexStr);
                    if (index != -1)
                        list[index] = item;
                    await Extensions.SetNotificationsLocalStorage(LocalStorageService, list);
                    notificationList = ReloadTableWithoutState(list);
                    await ApplicationState.UpdateStoreState();
                    StateHasChanged();
                    await Navigate(item);
                }
            }   
        }
        protected async Task<List<NotificationModel>> GetNotificationFromLS()
        {
            return await Extensions.GetNotifications(LocalStorageService);
        }

        protected string Action(NotificationModel notification)
        {
            if (notification.StatusAction == Enums.ActionMode.Create)
                return String.Format("Created a {0} ", notification.ModuleName.ToLower());
            else if (notification.StatusAction == Enums.ActionMode.Approve)
                return String.Format("Approved your {0}", notification.ModuleName.ToLower());
            else if (notification.StatusAction == Enums.ActionMode.Receive)
                return String.Format("Received your {0}", notification.ModuleName.ToLower());
            else
                return String.Format("Your {0} has been {1} ", notification.ModuleName.ToLower(),
                Extensions.PastTense(notification.StatusAction.ToString().ToLower()));
        }

        private List<NotificationModel> ReloadTableWithoutState(List<NotificationModel> list)
        {
            if (viewType == Enums.NotificationViewType.Read)
                return list.Where(x => x.IsSeen).ToList();
            else if (viewType == Enums.NotificationViewType.Unread)
                return list.Where(x => x.IsSeen == false).ToList();
            else
                return list;
        }
        protected async Task Refresh()
        {
            dataFetched = false;
            await FilterNotificationList(viewType);
            CompletedFetch();
        }
    }
}