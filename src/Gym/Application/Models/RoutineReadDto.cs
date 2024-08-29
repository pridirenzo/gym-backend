using Domain.Enum;

namespace Application.Models
{
    public class RoutineReadDto
    {
        public int RoutineId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<int> ExercisesId { get; set; }
    }
}
