using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;
using DziennikTreningowy.Core.Models;
using System.Linq;
using System.Collections.Generic;

namespace DziennikTreningowy.Infrastructure.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;

        public WorkoutService(
            IWorkoutRepository workoutRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public WorkoutDTO GetWorkout(int workoutId)
        {
            var workout = _workoutRepository.Get(workoutId);
            return MapWorkoutDTO(workout);
        }

        public WorkoutDTO GetUserWorkout(int userId, int workoutId)
        {
            var user = _userRepository.Get(userId);
            var workout = user.UserWorkouts.FirstOrDefault(x => x.WorkoutId == workoutId);
            return MapWorkoutDTO(workout);
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
