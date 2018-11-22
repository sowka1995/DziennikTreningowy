using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DziennikTreningowy.Infrastructure.Services
{
    public class WorkoutTemplateService : IWorkoutTemplateService
    {
        private readonly IUserRepository _userRepository;
        private readonly IWorkoutTemplateRepository _workoutTemplateRepository;
        private readonly IMapper _mapper;

        public WorkoutTemplateService(
            IWorkoutTemplateRepository workoutTemplateRepository,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _workoutTemplateRepository = workoutTemplateRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public WorkoutTemplateDTO GetWorkoutTemplate(int workoutTemplateId)
        {
            var workoutTemplate = _workoutTemplateRepository.Get(workoutTemplateId);
            return _mapper.Map<WorkoutTemplateDTO>(workoutTemplate);
        }

        public WorkoutTemplateDTO GetUserWorkoutTemplate(int userId, int workoutTemplateId)
        {
            var user = _userRepository.Get(userId);
            var workoutTemplate = user.WorkoutTemplates.FirstOrDefault(x => x.WorkoutTemplateId == workoutTemplateId);
            return _mapper.Map<WorkoutTemplateDTO>(workoutTemplate);
        }

        public IEnumerable<WorkoutTemplateDTO> GetUserWorkoutTemplates(int userId)
        {
            var user = _userRepository.Get(userId);
            var templates = user.WorkoutTemplates;
            return _mapper.Map<IEnumerable<WorkoutTemplateDTO>>(templates);
        }
    }
}
