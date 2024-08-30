using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMachineRepository : IRepository
    {
        ICollection<Machine> GetAllMachines();

        Machine GetMachineById(int id);
    }
}
