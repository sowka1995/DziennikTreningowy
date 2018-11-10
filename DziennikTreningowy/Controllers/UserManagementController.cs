using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DziennikTreningowy.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserManagementController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserManagementController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Zwraca informacje o zalogowanym użytkowniku
        /// </summary>
        /// <returns></returns>
        /// <response code="401">Wymagana autoryzacja</response>
        [HttpGet, Route("Information"), Authorize("Bearer")]
        public ActionResult<UserDTO> Information()
        {
            var currentUserId = User.GetUserId();

            return _userService.GetUserInfo(currentUserId.Value);
        }
    }
}
