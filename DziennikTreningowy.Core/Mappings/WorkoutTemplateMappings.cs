using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Models;
using System.Linq;

namespace DziennikTreningowy.Core.Mappings
{
    public class WorkoutTemplateMappings : Profile
    {
        public WorkoutTemplateMappings()
        {
            CreateMap<WorkoutTemplate, WorkoutTemplateDTO>()
                .ForMember(x => x.Id, opts => opts.MapFrom(i => i.WorkoutTemplateId))
                .ForMember(x => x.Exercises, opts =>
                    opts.MapFrom(i => i.WorkoutTemplateExercises.Select(w => w.Exercise).ToList()));
        }
    }
}
