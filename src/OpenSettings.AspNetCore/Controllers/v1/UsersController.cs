using Microsoft.AspNetCore.Mvc;
using Ogu.Response;
using OpenSettings.AspNetCore.Models.Requests;
using OpenSettings.Models.Inputs;
using OpenSettings.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _usersService.CreateUserAsync(new CreateUserInput
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

            var result = await _usersService.GetPaginatedUsersAsync(
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

            var result = await _usersService.GetUserByIdAsync(new GetUserInput { UserIdOrSlug = request.UserIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpGet("slug/{UserIdOrSlug}")]
        public async Task<IActionResult> GetUserBySlug(GetUserRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _usersService.GetUserBySlugAsync(new GetUserInput { UserIdOrSlug = request.UserIdOrSlug }, cancellationToken);

            return result.ToAction();
        }

        [HttpPut("{UserId}")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest request, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
            {
                return ModelState.ToAction();
            }

            var result = await _usersService.UpdateUserAsync(new UpdateUserInput
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

            var result = await _usersService.DeleteUserAsync(new DeleteUserInput { UserId = request.UserId }, cancellationToken);

            return result.ToAction();
        }
    }
}