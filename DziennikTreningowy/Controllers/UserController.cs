using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DziennikTreningowy.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Zwraca informacje o zalogowanym użytkowniku
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Informacje o użytkowniku</response>
        /// <response code="401">Użytkownik niezalogowany</response>
        /// <response code="500">Wewnętrzny błąd serwera</response>
        [ProducesResponseType(typeof(UserDTO), 200), ProducesResponseType(401)]
        [HttpGet, Route("informations"), Authorize("Bearer")]
        public ActionResult<UserDTO> GetUserInformation()
        {
            var currentUserId = User.GetUserId().Value;

            return _userService.GetUser(currentUserId);
        }
    }
}
