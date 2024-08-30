using Application.Models;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IMachineService
    {
        ICollection<MachineDto> GetAllMachines();
        MachineDto GetMachineById(int id);
    }
}

