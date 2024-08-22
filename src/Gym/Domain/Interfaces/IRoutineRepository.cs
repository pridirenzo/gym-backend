using Domain.Entities;
using Domain.Enum;

namespace Domain.Interfaces
{
    public interface IRoutineRepository : IRepository
    {
        IEnumerable<Routine> GetAllRoutine();
        Routine GetRoutineById(int routineId);
        IEnumerable<Routine> GetRoutineForDifficulty(Difficulty difficulty);
        void CreateRoutine (Routine routine);
        void DeleteRoutine (Routine routine);
        void UpdateRoutine (Routine routine);

    }
}
