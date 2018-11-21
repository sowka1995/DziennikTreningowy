using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Models;

namespace DziennikTreningowy.Core.Mappings
{
    public class ExerciseMappings : Profile
    {
        public ExerciseMappings()
        {
            CreateMap<Exercise, ExerciseDTO>()
                .ForMember(x => x.Id, opts => opts.MapFrom(i => i.ExerciseId));

            CreateMap<WorkoutExercise, WorkoutExerciseDTO>()
                .ForMember(x => x.Id, opts => opts.MapFrom(i => i.WorkoutExerciseId));

            CreateMap<WorkoutExercise, ExerciseSetDTO>()
                .ForMember(x => x.Id, opts => opts.MapFrom(i => i.WorkoutExerciseId));
        }
    }
}
