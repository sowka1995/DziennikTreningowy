using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DziennikTreningowy.Core.Models
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            UserWorkouts = new HashSet<Workout>();
            UserExercises = new HashSet<UserExercise>();
            WorkoutTemplates = new HashSet<WorkoutTemplate>();
        }

        [Key]
        public override int Id { get; set; }

        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public override string Email { get; set; }

        [MaxLength(1000)]
        public byte[] Avatar { get; set; }

        public virtual ICollection<Workout> UserWorkouts { get; set; }

        public virtual ICollection<UserExercise> UserExercises { get; set; }

        public virtual ICollection<WorkoutTemplate> WorkoutTemplates { get; set; }
    }
}
