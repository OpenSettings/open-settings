namespace OpenSettings.Models
{
    public enum NotificationSource
    {
        /// <summary>
        /// Represents notifications created by the user.
        /// </summary>
        User = 1,

        /// <summary>
        /// Represents notifications created by the system.
        /// </summary>
        System = 2,

        /// <summary>
        /// Represents notifications created by the OpenSettings.
        /// </summary>
        OpenSettings = 3
    }
}