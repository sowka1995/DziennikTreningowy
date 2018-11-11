using DziennikTreningowy.Core.DTO;
using System.Collections.Generic;

namespace DziennikTreningowy.Core.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUserInfo(int userId);
        IEnumerable<ExerciseDTO> GetUserExercises(int userId);
    }
}
