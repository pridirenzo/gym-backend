using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IMachineRepository _machineRepository;

        public MachineController(IMachineRepository machineRepository)
        {
            _machineRepository = machineRepository;
        }

        [HttpGet("GetAllMachine")]
        public async Task<IActionResult> GetAllMachines()
        {
            var machines = await _machineRepository.GetAllMachines();

            if (machines == null || !machines.Any())
            {
                return NotFound("No machines found");
            }

            return Ok(machines);
        }

        [HttpGet("GetById/{machineId}")]
        public async Task<IActionResult> GetMachineById(int machineId)
        {
            var machine = await _machineRepository.GetMachineById(machineId);

            if (machine == null)
            {
                return NotFound("Machine not found");
            }

            return Ok(machine);
        }
    }
}