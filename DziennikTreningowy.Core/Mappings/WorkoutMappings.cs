using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Models;

namespace DziennikTreningowy.Core.Mappings
{
    public class WorkoutMappings : Profile
    {
        public WorkoutMappings()
        {
            CreateMap<Workout, WorkoutDTO>()
                .ForMember(x => x.Id, opts => opts.MapFrom(i => i.WorkoutId));
        }
    }
}
