using Domain.Entities;
using Infraestructure.Data;
using Infrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data.Repositories
{
    public class MachineRepository : IMachineRepository
    {
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
}