using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ExerciseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        [ForeignKey("MachineId")]
        public Machine? Machines { get; set; }
        public int? MachineId { get; set; }
        public ICollection<RoutineExercise> RoutineExercise { get; set; }
    }
}
