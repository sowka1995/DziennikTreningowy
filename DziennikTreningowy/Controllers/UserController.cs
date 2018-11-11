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
        /// <response code="401">Użytkownik niezalogowany</response>
        [HttpGet, Route("Informations"), Authorize("Bearer")]
        public ActionResult<UserDTO> GetInformation()
        {
            var currentUserId = User.GetUserId();

            return _userService.GetUserInfo(currentUserId.Value);
        }

        /// <summary>
        /// Zwraca listę wszystkich ćwiczeń zalogowanego użytkownika
        /// </summary>
        /// <returns></returns>
        /// <response code="401">Użytkownik niezalogowany</response>
        [HttpGet, Route("Exercises"), Authorize("Bearer")]
        public ActionResult<IEnumerable<ExerciseDTO>> GetAllExercises()
        {
            var currentUserId = User.GetUserId();

            return _userService.GetUserExercises(currentUserId.Value).ToList();
        }
    }
}
