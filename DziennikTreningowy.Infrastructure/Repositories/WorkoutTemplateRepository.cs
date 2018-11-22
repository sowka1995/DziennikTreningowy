using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Core.Models;
using DziennikTreningowy.Infrastructure.Context;

namespace DziennikTreningowy.Infrastructure.Repositories
{
    public class WorkoutTemplateRepository : GenericRepository<WorkoutTemplate> ,IWorkoutTemplateRepository
    {
        public WorkoutTemplateRepository(WorkoutDiaryDbContext context)
            : base(context)
        {

        }
    }
}
