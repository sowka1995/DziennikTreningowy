
namespace DziennikTreningowy.Core.Models
{
    public class UserExercise
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
