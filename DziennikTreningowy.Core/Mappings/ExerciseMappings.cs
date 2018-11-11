using AutoMapper;
using DziennikTreningowy.Core.DTO;
using DziennikTreningowy.Core.Models;

namespace DziennikTreningowy.Core.Mappings
{
    public class ExerciseMappings : Profile
    {
        public ExerciseMappings()
        {
            CreateMap<Exercise, ExerciseDTO>().ReverseMap();
        }
    }
}
