using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Models;

namespace DziennikTreningowy.Core.Mappings
{
    public class WorkoutTemplateMappings : Profile
    {
        public WorkoutTemplateMappings()
        {
            CreateMap<WorkoutTemplate, WorkoutTemplateDTO>();
        }
    }
}
