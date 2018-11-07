using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikTreningowy.Core.Models
{
    public class WorkoutTemplate
    {
        [Key]
        public int WorkoutTemplateId { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<WorkoutTemplateExercise> WorkoutTemplateExercises { get; set; }
    }
}
