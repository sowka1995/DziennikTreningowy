using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikTreningowy.Core.Models
{
    public class Workout
    {
        public Workout()
        {
            WorkoutExercises = new HashSet<WorkoutExercise>();
        }

        [Key]
        public int WorkoutId { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        public virtual ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
