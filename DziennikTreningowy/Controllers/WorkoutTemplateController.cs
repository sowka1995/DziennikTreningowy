using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DziennikTreningowy.Controllers
{
    [Route("api/workoutTemplate")]
    [ApiController]
    public class WorkoutTemplateController : ControllerBase
    {
        private readonly IWorkoutTemplateService _workoutTemplateService;

        public WorkoutTemplateController(IWorkoutTemplateService workoutTemplateService)
        {
            _workoutTemplateService = workoutTemplateService;
        }

        /// <summary>
        /// Zwraca listę wszystkich szablonów treningowych zalogowanego użytkownika
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Lista szablonów treningowych</response>
        /// <response code="401">Użytkownik niezalogowany</response>
        /// <response code="500">Wewnętrzny błąd serwera</response>
        [ProducesResponseType(typeof(WorkoutTemplateDTO), 200), ProducesResponseType(401)]
        [HttpGet, Route("workoutTemplates"), Authorize("Bearer")]
        public ActionResult<IEnumerable<WorkoutTemplateDTO>> GetUserAllWorkoutTemplates()
        {
            var currentUserId = User.GetUserId().Value;

            return _workoutTemplateService.GetUserWorkoutTemplates(currentUserId).ToList();
        }
    }
}
