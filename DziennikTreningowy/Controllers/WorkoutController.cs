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
    [ApiController]
    [Route("api/workout")]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        /// <summary>
        /// Zwraca listę wszystkich treningów użytkownika
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("workouts"), Authorize("Bearer")]
        public ActionResult<IEnumerable<WorkoutDTO>> GetUserAllWorkouts()
        {
            var currentUserId = User.GetUserId().Value;

            return _workoutService.GetUserWorkouts(currentUserId).ToList();
        }
    }
}
