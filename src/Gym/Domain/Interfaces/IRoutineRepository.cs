using Domain.Entities;
using Domain.Enum;

namespace Domain.Interfaces
{
    public interface IRoutineRepository : IRepository
    {
        IEnumerable<Routine> GetAllRoutine();
        IEnumerable<Routine> GetRoutineByDifficulty(Difficulty difficulty);
        public Routine GetRoutineById(int routineId);
        void CreateRoutine(Routine routine);
        void DeleteRoutine(Routine routine);
        void UpdateRoutine(Routine routine);

    }
}
