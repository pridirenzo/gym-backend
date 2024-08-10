using Domain.Entities;
using Domain.Enum;
using Domain.Intefaces;
using Infraestructure.Data;

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
            return _context.Routines.Where(r => r.Difficulty == difficulty).ToList();
        }

        public void CreateRoutine(Routine routine)
        {
            _context.Routines.Add(routine);
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
    }
}
