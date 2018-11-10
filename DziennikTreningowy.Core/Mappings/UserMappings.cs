using AutoMapper;
using DziennikTreningowy.Core.Models;
using DziennikTreningowy.Core.DTO;

namespace DziennikTreningowy.Core.Mappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
