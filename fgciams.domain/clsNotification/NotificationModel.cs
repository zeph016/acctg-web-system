using fgciams.domain.clsEnums;
using fgciams.domain.clsUserAccount;

namespace fgciams.domain.clsNotification
{
    public class NotificationModel
    {
        public Int64 ApproverId { get; set; }
        public Int64 SenderId { get; set; }
        public Int64 PreparedById { get; set; }
        public Enums.ActionMode StatusAction { get; set; }
        public UserAccount Sender { get; set; } = new();
        public bool IsSeen { get; set; }
        public string ModuleName { get; set; } = string.Empty;
        public string ControlNumber { get; set; } = string.Empty;
        public DateTime DateNotify { get; set; }
        public string TimeElapseText
        {
            get
            {
                TimeSpan timeSpan = DateTime.Now.Subtract(DateNotify);

                return timeSpan.TotalSeconds switch
                {
                    <= 60 => $"a few seconds ago",

                    _ => timeSpan.TotalMinutes switch
                    {
                        <= 1 => "about a minute ago",
                        < 60 => $"about {timeSpan.Minutes} minutes ago",
                        _ => timeSpan.TotalHours switch
                        {
                            <= 1 => "about an hour ago",
                            < 24 => $"about {timeSpan.Hours} hours ago",
                            _ => timeSpan.TotalDays switch
                            {
                                <= 1 => "yesterday",
                                <= 30 => $"about {timeSpan.Days} days ago",

                                <= 60 => "about a month ago",
                                < 365 => $"about {timeSpan.Days / 30} months ago",

                                <= 365 * 2 => "about a year ago",
                                _ => $"about {timeSpan.Days / 365} years ago"
                            }
                        }
                    }
                };
            }
        }

        public string TempId
        {
            get { return ApproverId + DateNotify.ToString("yyyy") + DateNotify.ToString("HH:mm"); }
        }
   }
}