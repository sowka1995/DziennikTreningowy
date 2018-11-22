using DziennikTreningowy.Core.DTO;
using System.Collections.Generic;

namespace DziennikTreningowy.Core.Interfaces
{
    public interface IWorkoutTemplateService
    {
        WorkoutTemplateDTO GetWorkoutTemplate(int workoutTemplateId);

        WorkoutTemplateDTO GetUserWorkoutTemplate(int userId, int workoutTemplateId);
        IEnumerable<WorkoutTemplateDTO> GetUserWorkoutTemplates(int userId);
    }
}
