using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IMachineService _machineService;

        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpGet("GetAllMachine")]
        public IActionResult GetAllMachines()
        {
            return Ok(_machineService.GetAllMachines());
        }

        [HttpGet("GetById/{machineId}")]
        public IActionResult GetMachineById(int machineId)
        {
            try
            {
                return Ok(_machineService.GetMachineById(machineId));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}