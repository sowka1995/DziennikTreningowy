using DziennikTreningowy.Core.DTO;

namespace DziennikTreningowy.Core.Interfaces
{
    public interface IUserService
    {
        UserDTO GetUserInfo(int id);
    }
}
