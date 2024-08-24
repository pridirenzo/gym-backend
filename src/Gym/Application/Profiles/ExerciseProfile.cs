using AutoMapper;
using Application.Models;
using Domain.Entities;

namespace Application.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<Exercise, ExerciseDto>();
            CreateMap<ExerciseDto, Exercise>();
        }
    }
}
