using Application.Interfaces;
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Application.Services
{
    public class ExercisesValidatorService : IExercisesValidatorService
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExercisesValidatorService(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        public void ValidateExercises(List<int> exercisesId)
        {
            if (exercisesId == null || !exercisesId.Any())
                throw new ArgumentException("Exercise IDs cannot be null or empty.");

            var exercises = _exerciseRepository.GetExercisesByIds(exercisesId);

            var validExerciseIds = exercises.Select(e => e.ExerciseId).ToHashSet();
            var invalidExerciseIds = exercisesId.Except(validExerciseIds).ToList();

            if (invalidExerciseIds.Any())
                throw new ValidationException($"The following exercise IDs are invalid and do not exist: {string.Join(", ", invalidExerciseIds)}");

            var categoryCounts = exercises.GroupBy(e => e.Category)
                                          .ToDictionary(g => g.Key, g => g.Count());

            var exceededCategories = categoryCounts.Where(cv => cv.Value > 3).Select(cv => cv.Key).ToList();

            if (exceededCategories.Any())
                throw new ValidationException($"The given exercises exceed the 3 exercises per category limit: {string.Join(", ", exceededCategories)}");

            var machineCount = exercises.Count(e => e.MachineId.HasValue);

            if (machineCount > 5)
                throw new ValidationException($"The given exercises exceed the 5 machines per routine limit: {machineCount}");
        }
    }
}