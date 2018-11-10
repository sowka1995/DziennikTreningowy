using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Core.Models;
using DziennikTreningowy.Infrastructure.Context;

namespace DziennikTreningowy.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(WorkoutDiaryDbContext context)
            : base(context)
        {

        }
    }
}
