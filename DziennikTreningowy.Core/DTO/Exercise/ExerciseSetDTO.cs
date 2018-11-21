namespace DziennikTreningowy.Core.DTO
{
    public class ExerciseSetDTO
    {
        /// <summary>
        /// Id serii
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Numer serii
        /// </summary>
        public int SetNumber { get; set; }

        /// <summary>
        /// Liczba powtórzeń w serii
        /// </summary>
        public int NumberOfReps { get; set; }

        /// <summary>
        /// Ciężar jakim ćwiczono w serii
        /// </summary>
        public double Weight { get; set; }
    }
}
