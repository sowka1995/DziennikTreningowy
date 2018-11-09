namespace DziennikTreningowy.Core.Models
{
    public class WorkoutTemplateExercise
    {
        public int WorkoutTemplateId { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
