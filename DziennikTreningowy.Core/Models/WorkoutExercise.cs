using System.ComponentModel.DataAnnotations;

namespace DziennikTreningowy.Core.Models
{
    public class WorkoutExercise
    {
        [Key]
        public int WorkoutExerciseId { get; set; }

        public int SetNumber { get; set; }

        public int NumberOfReps { get; set; }

        public double Weight { get; set; }

        public virtual Exercise Exercise { get; set; }
    }
}
