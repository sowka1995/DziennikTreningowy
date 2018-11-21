using System;
using System.Collections.Generic;

namespace DziennikTreningowy.Core.DTO
{
    public class WorkoutDTO
    {
        /// <summary>
        /// Id treningu
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Czas odbycia treningu
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Miejsce wykonania treningu
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Ćwiczenia i serie wykonane na danym treningu
        /// </summary>
        public IEnumerable<WorkoutExerciseDTO> WorkoutExercises { get; set; }
    }
}
