using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using OpenSettings.AspNetCore.Extensions;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route(OpenSettingsDefaults.Routes.V1.Users)]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _userService.CreateUserAsync(new CreateUserInput
            {
                Email = request.Body.Email,
                Username = request.Body.Username,
                Password = request.Body.Password,
                Name = request.Body.Name,
                CreatedById = User.GetUserId()
            }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedUsers(GetPaginatedRequest request, CancellationToken cancellationToken = default)
        {
            if(!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _userService.GetPaginatedUsersAsync(
                new GetPaginatedInput(request.SearchTerm, request.SearchBy, request.PageIndex, request.PageSize,
                    request.SortBy, request.SortDirection), cancellationToken);

            return result.ToAction();
        }

        [HttpGet("{UserIdOrSlug}")]
        public async Task<IActionResult> GetUserById(GetUserRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _userService.GetUserByIdAsync(new GetUserInput { UserIdOrSlug = request.UserIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{UserIdOrSlug}")]
        public async Task<IActionResult> GetUserBySlug(GetUserRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _userService.GetUserBySlugAsync(new GetUserInput { UserIdOrSlug = request.UserIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut("{UserId}")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _userService.UpdateUserAsync(new UpdateUserInput
            {

            }, cancellationToken);

            return result.ToAction();
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> DeleteUser(DeleteUserRequest request,
            CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _userService.DeleteUserAsync(new DeleteUserInput { UserId = request.UserId }, cancellationToken);

            return result.ToAction();
        }
    }
}