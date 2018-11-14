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
        [HttpGet, Route("Informations"), Authorize("Bearer")]
        public ActionResult<UserDTO> GetUserInformation()
        {
            var currentUserId = User.GetUserId();

            return _userService.GetUserInfo(currentUserId.Value);
        }

        /// <summary>
        /// Zwraca listę wszystkich ćwiczeń zalogowanego użytkownika
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Lista ćwiczeń</response>
        /// <response code="401">Użytkownik niezalogowany</response>
        /// <response code="500">Wewnętrzny błąd serwera</response>
        [ProducesResponseType(typeof(ExerciseDTO), 200), ProducesResponseType(401)]
        [HttpGet, Route("Exercises"), Authorize("Bearer")]
        public ActionResult<IEnumerable<ExerciseDTO>> GetUserAllExercises()
        {
            var currentUserId = User.GetUserId();

            return _userService.GetUserExercises(currentUserId.Value).ToList();
        }

        /// <summary>
        /// Zwraca listę wszystkich szablonów treningowych zalogowanego użytkownika
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Lista szablonów treningowych</response>
        /// <response code="401">Użytkownik niezalogowany</response>
        /// <response code="500">Wewnętrzny błąd serwera</response>
        [ProducesResponseType(typeof(WorkoutTemplateDTO), 200), ProducesResponseType(401)]
        [HttpGet, Route("WorkoutTemplates"), Authorize("Bearer")]
        public ActionResult<IEnumerable<WorkoutTemplateDTO>> GetUserAllWorkoutTemplates()
        {
            var currentUserId = User.GetUserId();

            return _userService.GetUserWorkoutTemplates(currentUserId.Value).ToList();
        }
    }
}
