using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Enum;
using Domain.Interfaces;

namespace Application.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;
        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }
        public ICollection<ExerciseDto> GetAllExercise()
        {
            var exercises = _exerciseRepository.GetAllExercise();
            return _mapper.Map<ICollection<ExerciseDto>>(exercises);
        }

        public ICollection<ExerciseDto> GetExerciseByCategory(Category category)
        {
            var exercises = _exerciseRepository.GetExerciseByCategory(category);
            return _mapper.Map<ICollection<ExerciseDto>>(exercises);
        }

        public ExerciseDto GetExerciseById(int id)
        {
            var exercise = _exerciseRepository.GetExerciseById(id);
            if (exercise == null) throw new KeyNotFoundException($"The given key '{id}' does not correspond to an exercise.");
            return _mapper.Map<ExerciseDto>(exercise);
        }
    }
}
