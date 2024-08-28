using Application.Interfaces;
using Domain.Entities;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Services
{
    public class MachineRepository : IMachineRepository
    {
        // maquinas hardcodeadas
        private static readonly List<Machine> _machines = new List<Machine>
        {
            new Machine { MachineId = 1, Name = "Machine 1", Category = Category.Chest },
            new Machine { MachineId = 2, Name = "Machine 2", Category = Category.ABS }
        };


        public Task<IEnumerable<Machine>> GetAllMachines()
        {
            return Task.FromResult(_machines.AsEnumerable());
        }

        public Task<Machine> GetMachineById(int id)
        {
            var machine = _machines.FirstOrDefault(m => m.MachineId == id);
            return Task.FromResult(machine);
        }
    }
}
/* Metodo original para db
 * 
 private readonly GymContext _context;

public MachineRepository(GymContext context)
{
    _context = context;
}

public async Task<IEnumerable<Machine>> GetAllMachines()
{
    return await _context.Machines.ToListAsync();
}

public async Task<Machine> GetMachineById(int id)
{
    return await _context.Machines.FirstOrDefaultAsync(m => m.MachineId == id);
}
}
}*/
