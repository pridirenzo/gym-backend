using Domain.Entities;
using Domain.Enum;

namespace Domain.Intefaces
{
    public interface IRoutineRepository : IRepository
    {
        IEnumerable<Routine> GetAllRoutine();
        IEnumerable<Routine> GetRoutineForDifficulty(Difficulty difficulty);
        void CreateRoutine (Routine routine);
        void DeleteRoutine (Routine routine);
        void UpdateRoutine (Routine routine);

    }
}
