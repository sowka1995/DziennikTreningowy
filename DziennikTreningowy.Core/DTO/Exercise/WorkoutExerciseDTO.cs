using System.Collections.Generic;

namespace DziennikTreningowy.Core.DTO
{
    public class WorkoutExerciseDTO
    {
        /// <summary>
        /// Id ćwiczenia w treningu
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Informacje o wykonanym ćwiczeniu
        /// </summary>
        public ExerciseDTO Exercise { get; set; }

        /// <summary>
        /// Serie wykonane w danym ćwiczeniu
        /// </summary>
        public IEnumerable<ExerciseSetDTO> ExerciseSets { get; set; }
    }
}
