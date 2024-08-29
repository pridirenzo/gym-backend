using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;

namespace Infrastructure.Data
{
    public class ExerciseRepository : Repository , IExerciseRepository
    {
        public ExerciseRepository(GymContext context) : base(context)
        {
        }

        public ICollection<Exercise> GetAllExercise()
        {
            return _context.Exercises.ToList();
        }

        public ICollection<Exercise> GetExerciseByCategory(Category category)
        {
            return _context.Exercises.Where(e => e.Category == category).ToList();
        }

        public Exercise GetExerciseById(int id)
        {
            return _context.Exercises.Find(id);
        }
    }
}