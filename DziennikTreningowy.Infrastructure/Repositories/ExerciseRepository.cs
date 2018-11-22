using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Core.Models;
using DziennikTreningowy.Infrastructure.Context;

namespace DziennikTreningowy.Infrastructure.Repositories
{
    public class ExerciseRepository : GenericRepository<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(WorkoutDiaryDbContext context)
            : base(context)
        {

        }
    }
}
