using DziennikTreningowy.Core.DTO;
using System.Collections.Generic;

namespace DziennikTreningowy.Core.Interfaces
{
    public interface IWorkoutService
    {
        WorkoutDTO GetWorkout(int workoutId);

        WorkoutDTO GetUserWorkout(int userId, int workoutId);
        IEnumerable<WorkoutDTO> GetUserWorkouts(int userId);
    }
}
