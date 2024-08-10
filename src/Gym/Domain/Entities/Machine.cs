using Domain.Enum;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Machine
    {
        [Required]
        public int MachineId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        public ICollection<Exercise> Exercises { get; set;}
        
    }

}
