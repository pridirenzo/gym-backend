using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRoutineExerciseRepository
    {
        public ICollection<RoutineExercise> GetRoutineExercises(int routineId);
        public IList<int> GetRoutineExercisesIds(int routineId);
        public void CreateRoutineExcercises(IEnumerable<RoutineExercise> routineExercises);
        public void DeleteRoutineExercises(IEnumerable<RoutineExercise> routineExercises);
    }
}
