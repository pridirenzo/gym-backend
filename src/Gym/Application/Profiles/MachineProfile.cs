using AutoMapper;
using Application.Models;
using Domain.Entities;

namespace Application.Profiles
{
    public class MachineProfile : Profile
    {
        public MachineProfile()
        {
            CreateMap<Machine, MachineDto>();
            CreateMap<MachineDto, Machine>();
        }
    }
}
