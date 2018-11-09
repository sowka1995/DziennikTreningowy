using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikTreningowy.Core.Models
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }

        public DateTime Date { get; set; }

        [MaxLength(255)]
        public string Location { get; set; }

        public ICollection<WorkoutExercise> WorkoutExercises { get; set; }
    }
}
