using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;

namespace DziennikTreningowy.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserDTO GetUserInfo(int id)
        {
            var user = _userRepository.Get(id);
            return _mapper.Map<UserDTO>(user);
        }
    }
}
