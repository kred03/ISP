using AutoMapper;
using Lab5.Application.DTOs;
using Lab5.Domain.Entities;


namespace Lab5.Application.SuperPowerMappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
          CreateMap<Superhero, SuperheroDto>()
                .ForMember(dest => dest.Superpowers, opt => opt.MapFrom(src => src.Superpowers))
                .ReverseMap(); 

            CreateMap<Superpower, SuperpowerDto>().ReverseMap();
        }
    }
}
