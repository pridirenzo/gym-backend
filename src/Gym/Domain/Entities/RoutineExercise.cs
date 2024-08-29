﻿

namespace Domain.Entities
{
    public class RoutineExercise
    {
        public int RoutineId { get; set; }
        public Routine Routine { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public RoutineExercise(int routineId, int exerciseId)
        {
            RoutineId = routineId;
            ExerciseId = exerciseId;
        }
    }
}
