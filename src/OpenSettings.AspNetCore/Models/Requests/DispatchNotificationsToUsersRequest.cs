using Microsoft.AspNetCore.Mvc;
using System;

namespace OpenSettings.AspNetCore.Models.Requests
{
    public class DispatchNotificationsToUsersRequest
    {
        [FromRoute]
        public Guid NotificationId { get; set; }
    }
}