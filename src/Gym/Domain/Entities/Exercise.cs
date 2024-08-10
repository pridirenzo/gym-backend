using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Exercise
    {
        [Required]
        public int  ExerciseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        [ForeignKey("MachineId")]
        public Machine Machines { get; set; }
        public int MachineId { get; set; }
        public ICollection<RoutineExercise> RoutineExercises { get; set; }
    }
}
