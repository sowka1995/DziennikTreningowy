using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Core.Models;

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

        public IEnumerable<ExerciseDTO> GetUserExercises(int userId)
        {
            var user = _userRepository.Get(userId);
            var exercises = user.UserExercises.Select(x => x.Exercise);
            return _mapper.Map<IEnumerable<ExerciseDTO>>(exercises);
        }

        public UserDTO GetUserInfo(int userId)
        {
            var user = _userRepository.Get(userId);
            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<WorkoutTemplateDTO> GetUserWorkoutTemplates(int userId)
        {
            var user = _userRepository.Get(userId);
            var templates = user.WorkoutTemplates;
            return _mapper.Map<IEnumerable<WorkoutTemplateDTO>>(templates);
        }
    }
}
