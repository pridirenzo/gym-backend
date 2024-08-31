using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class RoutineExerciseService : IRoutineExerciseService
    { 
        private readonly IRoutineExerciseRepository _routineExerciseRepository;
        public RoutineExerciseService(IRoutineExerciseRepository routineExerciseRepository, IExerciseService exerciseService)
        {
            _routineExerciseRepository = routineExerciseRepository;
        }
        public List<int> GetRoutineExercises(int routineId)
        {
            return _routineExerciseRepository.GetRoutineExercisesIds(routineId).ToList();
        }

        public void CreateRoutineExercises(int routineId, List<int> exercisesId)
        {
            var routineExercises = new List<RoutineExercise>();
            foreach (var exerciseId in exercisesId)
            {
                var routineExercise = new RoutineExercise(routineId, exerciseId);
                routineExercises.Add(routineExercise);
            }
            _routineExerciseRepository.CreateRoutineExcercises(routineExercises);
        }

        public void DeleteRoutineExercises(int routineId)
        {
            var routineExercises = _routineExerciseRepository.GetRoutineExercises(routineId);
            _routineExerciseRepository.DeleteRoutineExercises(routineExercises);
        }

        public void UpdateRoutineExercises(int routineId, List<int> exercisesId)
        {
            var existingRoutineExercises = _routineExerciseRepository.GetRoutineExercises(routineId);

            var existingExercisesIds = new List<int>(existingRoutineExercises.Select(re => re.ExerciseId));

            var exercisesToAdd = exercisesId.Except(existingExercisesIds).Select(exerciseId => new RoutineExercise(routineId, exerciseId)).ToList();

            var exercisesToRemove = existingRoutineExercises.Where(re => !exercisesId.Contains(re.ExerciseId)).ToList();

            if (exercisesToRemove.Any())
            {
                _routineExerciseRepository.DeleteRoutineExercises(exercisesToRemove);
            }

            if (exercisesToAdd.Any())
            {
                _routineExerciseRepository.CreateRoutineExcercises(exercisesToAdd);
            }
        }
    }
}
