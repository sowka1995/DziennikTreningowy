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

        public IEnumerable<WorkoutDTO> GetUserWorkouts(int userId)
        {
            var user = _userRepository.Get(userId);
            var workouts = user.UserWorkouts;

            var workoutsDTO = new List<WorkoutDTO>();
            foreach (var workout in workouts)
            {
                var workoutDTO = MapWorkoutDTO(workout);
                workoutsDTO.Add(workoutDTO);
            }

            return workoutsDTO;
        }

        public IEnumerable<WorkoutTemplateDTO> GetUserWorkoutTemplates(int userId)
        {
            var user = _userRepository.Get(userId);
            var templates = user.WorkoutTemplates;
            return _mapper.Map<IEnumerable<WorkoutTemplateDTO>>(templates);
        }

        public WorkoutDTO GetUserWorkout(int userId, int workoutId)
        {
            var user = _userRepository.Get(userId);
            var workout = user.UserWorkouts.First(x => x.WorkoutId == workoutId);

            return MapWorkoutDTO(workout);
        }

        private WorkoutDTO MapWorkoutDTO(Workout workout)
        {
            var workoutDTO = _mapper.Map<WorkoutDTO>(workout);
            var workoutExercises = workout.WorkoutExercises.GroupBy(x => x.ExerciseId);

            var workoutExercisesDTO = new List<WorkoutExerciseDTO>();
            for (int i = 0; i < workoutExercises.Count(); i++)
            {
                var workoutExercise = workoutExercises.ElementAt(i).ToList();

                var workoutExerciseDTO = _mapper.Map<ExerciseDTO>(workoutExercise.First().Exercise);
                var workoutExerciseSetsDTO = _mapper.Map<IEnumerable<ExerciseSetDTO>>(workoutExercise);
                workoutExercisesDTO.Add(new WorkoutExerciseDTO
                {
                    Id = workoutExerciseDTO.Id,
                    Exercise = workoutExerciseDTO,
                    ExerciseSets = workoutExerciseSetsDTO
                });
            }
            workoutDTO.WorkoutExercises = workoutExercisesDTO;

            return workoutDTO;
        }
    }
}
