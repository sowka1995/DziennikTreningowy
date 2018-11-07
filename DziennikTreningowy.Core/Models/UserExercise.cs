
namespace DziennikTreningowy.Core.Models
{
    public class UserExercise
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
