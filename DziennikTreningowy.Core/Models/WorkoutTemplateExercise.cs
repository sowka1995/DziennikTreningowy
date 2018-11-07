namespace DziennikTreningowy.Core.Models
{
    public class WorkoutTemplateExercise
    {
        public int WorkoutTemplateId { get; set; }
        public virtual WorkoutTemplate WorkoutTemplate { get; set; }

        public int ExerciseId { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
