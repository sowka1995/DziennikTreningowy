using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikTreningowy.Core.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(1000)]
        public byte[] Avatar { get; set; }

        public ICollection<Workout> UserWorkouts { get; set; }

        public ICollection<UserExercise> UserExercises { get; set; }

        public ICollection<WorkoutTemplate> WorkoutTemplates { get; set; }
    }
}
