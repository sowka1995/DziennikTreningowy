using System.Collections.Generic;

namespace DziennikTreningowy.Core.DTO
{
    public class WorkoutTemplateDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ExerciseDTO> Exercises { get; set; }
    }
}