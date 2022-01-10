using AutoMapper;
using PersonApi.Dtos;
using PersonApi.Models;

namespace PersonApi.Profiles
{
    public class DogMappingProfile: Profile
    {
        public DogMappingProfile()
        {
            CreateMap<Dog, DogDto>();
            CreateMap<DogDto, Dog>();
        }
    }
}
