using Domain.Entities;
using Domain.Enum;

namespace Domain.Interfaces
{
    public interface IExerciseRepository : IRepository
    {
        ICollection<Exercise> GetAllExercise();
        ICollection<Exercise> GetExerciseByCategory(Category category);
        Exercise GetExerciseById(int id);
        ICollection<Exercise> GetExercisesByIds(IList<int> ids);
    }
}
