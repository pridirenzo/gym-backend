using Application.Common;
using Application.Models;
using Domain.Enum;

namespace Application.Interfaces
{
    public interface IRoutineService
    {
        IEnumerable<RoutineReadDto> GetAllRoutine();
        IEnumerable<RoutineDto> GetRoutineByDifficulty(Difficulty difficulty);
        RoutineDto GetRoutineById(int routineId);
        OperationResult CreateRoutine(RoutineDto routine);
        OperationResult DeleteRoutine(int routineId);
        OperationResult UpdateRoutine(int routineId, RoutineDto routine);
    }
}
