using Application.Common;
using Application.Models;
using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoutineService
    {
        IEnumerable<RoutineReadDto> GetAllRoutine();
        RoutineDto GetRoutineById(int routineId);
        IEnumerable<RoutineDto> GetRoutineForDifficulty(Difficulty difficulty);
        OperationResult CreateRoutine(RoutineDto routine);
        bool DeleteRoutine(int routineId);
        OperationResult UpdateRoutine(int routineId, RoutineDto routine);
    }
}
