namespace OpenSettings.Models.Responses
{
    public class GetUserNotificationsResponseNotificationCounts
    {
        public int Opened { get; set; }

        public int NotOpened { get; set; }

        public int Viewed { get; set; }

        public int NotViewed { get; set; }

        public int Dismissed { get; set; }

        public int NotDismissed { get; set; }
    }
}