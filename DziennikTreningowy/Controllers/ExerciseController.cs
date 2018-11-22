using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikTreningowy.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        /// <summary>
        /// Zwraca listę wszystkich ćwiczeń zalogowanego użytkownika
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Lista ćwiczeń</response>
        /// <response code="401">Użytkownik niezalogowany</response>
        /// <response code="500">Wewnętrzny błąd serwera</response>
        [ProducesResponseType(typeof(ExerciseDTO), 200), ProducesResponseType(401)]
        [HttpGet, Route("exercises"), Authorize("Bearer")]
        public ActionResult<IEnumerable<ExerciseDTO>> GetUserAllExercises()
        {
            var currentUserId = User.GetUserId().Value;

            return _exerciseService.GetUserExercises(currentUserId).ToList();
        }
    }
}
