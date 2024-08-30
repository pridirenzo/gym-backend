using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;


namespace Infrastructure.Data
{
    public class MachineRepository : Repository, IMachineRepository
    {
        public MachineRepository(GymContext context) : base(context)
        {
        }

        public ICollection<Machine> GetAllMachines()
        {
            return _context.Machines.ToList();
        }

        public Machine GetExerciseById(int id)
        {
            return _context.Machines.Find(id);
        }
    }
}
