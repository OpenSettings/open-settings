using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Extensions;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("")]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.GetNotifications)]
        public async Task<IActionResult> GetNotifications(GetNotificationsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _notificationService.GetNotificationsAsync(new GetNotificationsInput
            {
                IsExpired = request.IsExpired,
                Type = request.Type,
                Source = request.Source,
                PackVersion = HttpContext.Request.Headers.GetPackVersionHeaderValueOrDefault()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet(OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.GetUserNotifications)]
        public async Task<IActionResult> GetUserNotifications(GetUserNotificationsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var userId = User.GetUserId();

            if (userId != request.UserId)
            {
                HttpStatusCode.BadRequest.ToFailureResponse(Errors.UserNotMatched);
            }

            var result = await _notificationService.GetUserNotificationsAsync(new GetUserNotificationsInput
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

        [HttpPost(OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.CreateNotification)]
        public async Task<IActionResult> CreateNotification(CreateNotificationRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _notificationService.CreateNotificationAsync(new CreateNotificationInput
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

        [HttpPost(OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.MarkNotificationsAsOpened)]
        public async Task<IActionResult> MarkNotificationsAsOpened(MarkNotificationsAsOpenedRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var userId = User.GetUserId();

            if (userId != request.UserId)
            {
                HttpStatusCode.BadRequest.ToFailureResponse(Errors.UserNotMatched);
            }

            var result = await _notificationService.MarkNotificationsAsOpenedAsync(new MarkNotificationsAsOpenedInput
            {
                UserId = request.UserId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.MarkNotificationAsViewed)]
        public async Task<IActionResult> MarkNotificationAsViewed(MarkNotificationAsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var userId = User.GetUserId();

            if (userId != request.UserId)
            {
                HttpStatusCode.BadRequest.ToFailureResponse(Errors.UserNotMatched);
            }

            var result = await _notificationService.MarkNotificationAsViewedAsync(new MarkNotificationAsInput
            {
                NotificationId = request.NotificationId,
                UserId = request.UserId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.MarkNotificationAsDismissed)]
        public async Task<IActionResult> MarkNotificationAsDismissed(MarkNotificationAsRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var userId = User.GetUserId();

            if (userId != request.UserId)
            {
                HttpStatusCode.BadRequest.ToFailureResponse(Errors.UserNotMatched);
            }

            var result = await _notificationService.MarkNotificationAsDismissedAsync(new MarkNotificationAsInput
            {
                NotificationId = request.NotificationId,
                UserId = request.UserId
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpPost(OpenSettingsDefaults.Routes.V1.NotificationsEndpoints.DispatchNotificationsToUsers)]
        public async Task<IActionResult> DispatchNotificationsToUsers(DispatchNotificationsToUsersRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _notificationService.DispatchNotificationsToUsersAsync(new DispatchNotificationsToUsersInput
            {
                NotificationId = request.NotificationId
            }, cancellationToken);

            return result.ToAction();
        }
    }
}