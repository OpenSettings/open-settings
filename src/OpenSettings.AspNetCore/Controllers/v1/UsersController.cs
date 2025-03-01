using Microsoft.AspNetCore.Mvc;
using OpenSettings.Services.Interfaces;

namespace OpenSettings.AspNetCore.Controllers.v1
{
    [Route("v1")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
    }
}