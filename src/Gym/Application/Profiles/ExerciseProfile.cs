using AutoMapper;
using Application.Models;
using Domain.Entities;

namespace Application.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExerciseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ExerciseId))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.MachineId, opt => opt.MapFrom(src => src.MachineId));

            CreateMap<ExerciseDto, Exercise>()
                .ForMember(dest => dest.ExerciseId, opt => opt.Ignore())
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.MachineId, opt => opt.MapFrom(src => src.MachineId))
                .ForMember(dest => dest.Machines, opt => opt.Ignore())
                .ForMember(dest => dest.RoutineExercise, opt => opt.Ignore());
        }
    }
}
