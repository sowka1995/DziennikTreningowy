using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikTreningowy.Core.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public virtual ICollection<UserExercise> UserExercises { get; set; }

        public virtual ICollection<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; }
    }
}
