using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class RoutineReadDto
    {
        public int routineId { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public Difficulty Difficulty { get; set; }
    }
}
