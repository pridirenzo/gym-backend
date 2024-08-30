using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMachineRepository : IRepository
    {
        ICollection<Machine> GetAllMachines();

        Machine GetExerciseById(int id);
    }
}
