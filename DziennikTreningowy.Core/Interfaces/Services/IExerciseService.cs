using DziennikTreningowy.Core.DTO;
using System.Collections.Generic;

namespace DziennikTreningowy.Core.Interfaces
{
    public interface IExerciseService
    {
        ExerciseDTO GetExercise(int exerciseId);

        ExerciseDTO GetUserExercise(int userId, int exerciseId);
        IEnumerable<ExerciseDTO> GetUserExercises(int userId);
    }
}
