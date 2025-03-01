namespace OpenSettings.Models.Inputs
{
    public class GetNotificationsInput
    {
        public bool? IsExpired { get; set; }

        public NotificationType? Type { get; set; }

        public NotificationSource? Source { get; set; }

        public string PackVersion { get; set; }
    }
}