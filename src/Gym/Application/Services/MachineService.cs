
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Enum;
using Domain.Interfaces;

namespace Application.Services
{
    public class MachineService : IMachineService
    {
        
        private readonly IMachineRepository _machineRepository;
        private readonly IMapper _mapper;
        public MachineService(IMachineRepository machineRepository, IMapper mapper)
        {
            _machineRepository = machineRepository;
            _mapper = mapper;
        }

        public ICollection<MachineDto> GetAllMachines()
        {
            var machines = _machineRepository.GetAllMachines();
            return _mapper.Map<ICollection<MachineDto>>(machines);
        }

        public MachineDto GetMachineById(int id)
        {
            var machine = _machineRepository.GetMachineById(id);
            if (machine == null) throw new KeyNotFoundException($"The given key '{id}' does not correspond to a machine.");
            return _mapper.Map<MachineDto>(machine);
        }
    }
}
/*        // maquinas hardcodeadas
        private static readonly List<Machine> _machines = new List<Machine>
        {
            new Machine { MachineId = 1, Name = "Machine 1", Category = Category.Chest },
            new Machine { MachineId = 2, Name = "Machine 2", Category = Category.ABS }
        };
}*/
