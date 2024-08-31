using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class RoutineExerciseRepository : Repository, IRoutineExerciseRepository
    {
        public RoutineExerciseRepository(GymContext context) : base(context)
        {
        }

        public ICollection<RoutineExercise> GetRoutineExercises(int routineId)
        {
            return _context.RoutinesExercises.Where(re => re.RoutineId == routineId).ToList();
        }

        public IList<int> GetRoutineExercisesIds(int routineId)
        {
            return _context.RoutinesExercises.Where(re => re.RoutineId == routineId).Select(re => re.ExerciseId).ToList();
        }

        public void CreateRoutineExcercises(IEnumerable<RoutineExercise> routineExercises)
        {
            _context.RoutinesExercises.AddRange(routineExercises);
            SaveChanges();
        }

        public void DeleteRoutineExercises(IEnumerable<RoutineExercise> routineExercises)
        {
            _context.RoutinesExercises.RemoveRange(routineExercises);
            SaveChanges();
        }
    }
}
