using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Data
{
    public class RoutineRepository : Repository , IRoutineRepository
    {
        public RoutineRepository(GymContext context) : base(context)
        {
        }

        public IEnumerable<Routine> GetAllRoutine()
        {
            return _context.Routines.ToList();
        }

        public IEnumerable<Routine> GetRoutineForDifficulty(Difficulty difficulty)
        {
            return _context.Routines.Where(r => r.Difficulty == difficulty);
        }

        public void CreateRoutine(Routine routine)
        {
            _context.Routines.Add(routine);
            SaveChanges();
        }

        public void CreateRoutineExcercise(RoutineExercise routineExercise)
        {
            _context.RoutinesExercises.Add(routineExercise);
            SaveChanges();
        }

        public void DeleteRoutine(Routine routine)
        {
            _context.Routines.Remove(routine);
            SaveChanges();
        }
        public void UpdateRoutine(Routine routine)
        {
            _context.Routines.Update(routine);
            SaveChanges();
        }

        public Routine GetRoutineById(int routineId)
        {
            return _context.Routines.Find(routineId);
        }
    }
}
