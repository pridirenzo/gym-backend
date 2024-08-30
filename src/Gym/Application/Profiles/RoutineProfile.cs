using Application.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles
{
    public class RoutineProfile : Profile
    {
        public RoutineProfile() 
        {
            CreateMap<RoutineDto, Routine>();
            CreateMap<Routine, RoutineDto>();
        }
    }
}
