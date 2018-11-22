using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Core.Models;

namespace DziennikTreningowy.Infrastructure.Services
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

        public UserDTO GetUser(int userId)
        {
            var user = _userRepository.Get(userId);
            return _mapper.Map<UserDTO>(user);
        }       
    }
}
