using Application.Interfaces;
using Application.Models;
using Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly IRoutineService _routineService;

        public RoutineController(IRoutineService routineService)
        {
            _routineService = routineService;
        }

        [HttpGet("GetAllRoutine")]
        public IActionResult GetAllRoutine()
        {
            return Ok(_routineService.GetAllRoutine());
        }
        [HttpGet("GetById/{routineId}")]
        public IActionResult GetAllRoutine([FromRoute]int routineId)
        {
            return Ok(_routineService.GetRoutineById(routineId));
        }

        [HttpGet("GetRoutineByDifficulty")]
        public IActionResult GetRoutineByDifficulty([FromQuery] Difficulty difficulty)
        {
            return Ok(_routineService.GetRoutineForDifficulty(difficulty));
        }


        [HttpPost("CreateRoutine")]
        public IActionResult CreateRoutine([FromBody] RoutineDto routineDto) 
        { 
            var result = _routineService.CreateRoutine(routineDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete("DeleteRoutine/{routineId}")]
        public IActionResult DeleteRoutine([FromRoute] int routineId)
        {
            if (_routineService.GetRoutineById(routineId) == null)
            {
                return BadRequest("The Routine Does not exist");
            }
            _routineService.DeleteRoutine(routineId);
            return Ok("Deleted Success");
        }
        [HttpPut("UpdateRoutine/{routineId}")]
        public IActionResult UpdateRoutine([FromRoute] int routineId, [FromBody] RoutineDto routineDto)
        {
            var result = _routineService.UpdateRoutine(routineId, routineDto);
            if (result.Success)
            {
                _routineService.UpdateRoutine(routineId, routineDto);
                return  Ok(result.Message);
            }
            return BadRequest(result.Message); 
        }

    }
}
