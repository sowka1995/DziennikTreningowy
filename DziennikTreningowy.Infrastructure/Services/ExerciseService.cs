using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace DziennikTreningowy.Infrastructure.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IUserRepository _userRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public ExerciseService(
            IExerciseRepository exerciseRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public ExerciseDTO GetExercise(int exerciseId)
        {
            var exercise = _exerciseRepository.Get(exerciseId);
            return _mapper.Map<ExerciseDTO>(exercise);
        }

        public ExerciseDTO GetUserExercise(int userId, int exerciseId)
        {
            var user = _userRepository.Get(userId);
            var exercise = user.UserExercises.SingleOrDefault(x => x.ExerciseId == exerciseId);
            return _mapper.Map<ExerciseDTO>(exercise);
        }

        public IEnumerable<ExerciseDTO> GetUserExercises(int userId)
        {
            var user = _userRepository.Get(userId);
            var exercises = user.UserExercises.Select(x => x.Exercise);
            return _mapper.Map<IEnumerable<ExerciseDTO>>(exercises);
        }
    }
}
