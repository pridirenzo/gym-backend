using Domain.Enum;

namespace Application.Models
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int? MachineId { get; set; }
    }
}
