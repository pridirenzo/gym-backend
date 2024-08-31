using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRoutineExerciseService
    {
        public List<int> GetRoutineExercises(int routineId);
        public void CreateRoutineExercises(int routineId, List<int> exercisesId);
        public void DeleteRoutineExercises(int routineId);
        public void UpdateRoutineExercises(int routineId, List<int> exercisesId);
    }
}
