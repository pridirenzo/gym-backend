
using Domain.Enum;

namespace Application.Models
{
    public class MachineDto
    {
        public int MachineId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
