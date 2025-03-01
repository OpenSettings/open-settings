using Microsoft.AspNetCore.Mvc;
using Ogu.AspNetCore.Response.Json;
using Ogu.Response.Json;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/notifications")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationsService _notificationsService;

        public NotificationsController(INotificationsService notificationsService)
        {
            _notificationsService = notificationsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNotifications(GetNotificationsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _notificationsService.GetNotificationsAsync(new GetNotificationsInput
            {
                IsExpired = request.IsExpired,
                Type = request.Type,
                Source = request.Source,
                PackVersion = this.HttpContext.Request.Headers.GetPackVersionHeaderValueOrDefault()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("users/{UserId:guid}")]
        public async Task<IActionResult> GetUserNotifications(GetUserNotificationsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var userId = User.GetUserId();

            if (userId != request.UserId)
            {
                HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.UserNotMatched);
            }

            var result = await _notificationsService.GetUserNotificationsAsync(new GetUserNotificationsInput
            {
                UserId = request.UserId,
                IsOpened = request.IsOpened,
                IsViewed = request.IsViewed,
                IsDismissed = request.IsDismissed,
                IsExpired = request.IsExpired,
                Type = request.Type,
                Source = request.Source,
                PackVersion = this.HttpContext.Request.Headers.GetPackVersionHeaderValueOrDefault()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(CreateNotificationRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _notificationsService.CreateNotificationAsync(new CreateNotificationInput
            {
                Id = request.Body.Id,
                Title = request.Body.Title,
                Message = request.Body.Message,
                Type = request.Body.Type,
                Source = NotificationSource.User,
                CreatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("users/{UserId}/open")]
        public async Task<IActionResult> MarkNotificationsAsOpened(MarkNotificationsAsOpenedRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var userId = User.GetUserId();

            if (userId != request.UserId)
            {
                HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.UserNotMatched);
            }

            var result = await _notificationsService.MarkNotificationsAsOpenedAsync(new MarkNotificationsAsOpenedInput
            {
                UserId = request.UserId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{NotificationId}/users/{UserId}/view")]
        public async Task<IActionResult> MarkNotificationAsViewed(MarkNotificationAsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var userId = User.GetUserId();

            if (userId != request.UserId)
            {
                HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.UserNotMatched);
            }

            var result = await _notificationsService.MarkNotificationAsViewedAsync(new MarkNotificationAsInput
            {
                NotificationId = request.NotificationId,
                UserId = request.UserId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{NotificationId}/users/{UserId}/dismiss")]
        public async Task<IActionResult> MarkNotificationAsDismissed(MarkNotificationAsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var userId = User.GetUserId();

            if (userId != request.UserId)
            {
                HttpStatusCode.BadRequest.ToFailureJsonResponse(Errors.UserNotMatched);
            }

            var result = await _notificationsService.MarkNotificationAsDismissedAsync(new MarkNotificationAsInput
            {
                NotificationId = request.NotificationId,
                UserId = request.UserId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost("{NotificationId}/users/dispatch")]
        public async Task<IActionResult> DispatchNotificationsToUsers(DispatchNotificationsToUsersRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToJsonAction();
            }

            var result = await _notificationsService.DispatchNotificationsToUsersAsync(new DispatchNotificationsToUsersInput
            {
                NotificationId = request.NotificationId
            }, cancellationToken);

            return result.ToAction();
        }
    }
}