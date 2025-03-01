using OpenSettings.Models;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class CreateNotificationRequestBody
    {
        public Guid? Id { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public NotificationType Type { get; set; }

        public Guid? CreatedById { get; set; }
    }
}