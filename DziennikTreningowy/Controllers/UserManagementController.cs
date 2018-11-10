using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DziennikTreningowy.Controllers
{
    [Authorize("Bearer")]
    [Route("api/user")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("Information")]
        public ActionResult<UserDTO> Information()
        {
            var currentUserId = User.GetUserId();

            return _userService.GetUserInfo(currentUserId.Value);
        }
    }
}
