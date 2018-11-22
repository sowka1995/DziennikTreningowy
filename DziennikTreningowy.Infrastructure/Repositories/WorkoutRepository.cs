using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Core.Models;
using DziennikTreningowy.Infrastructure.Context;

namespace DziennikTreningowy.Infrastructure.Repositories
{
    public class WorkoutRepository : GenericRepository<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(WorkoutDiaryDbContext context) :
            base(context)
        {

        }
    }
}
