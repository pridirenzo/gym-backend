using Application.Interfaces;
using Application.Models;
using Domain.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Web.Controllers
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
        public IActionResult GetRoutineById([FromRoute] int routineId)
        {
            try
            {
                return Ok(_routineService.GetRoutineById(routineId));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetRoutineByDifficulty")]
        public IActionResult GetRoutineByDifficulty([FromQuery] Difficulty difficulty)
        {
            return Ok(_routineService.GetRoutineByDifficulty(difficulty));
        }

        [HttpPost("CreateRoutine")]
        public IActionResult CreateRoutine([FromBody] RoutineDto routineDto)
        {
            try
            {
                var result = _routineService.CreateRoutine(routineDto);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteRoutine/{routineId}")]
        public IActionResult DeleteRoutine([FromRoute] int routineId)
        {
            var result = _routineService.DeleteRoutine(routineId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("UpdateRoutine/{routineId}")]
        public IActionResult UpdateRoutine([FromRoute] int routineId, [FromBody] RoutineDto routineDto)
        {
            try
            {
                var result = _routineService.UpdateRoutine(routineId, routineDto);
                if (result.Success)
                {
                    _routineService.UpdateRoutine(routineId, routineDto);
                    return Ok(result.Message);
                }
                return BadRequest(result.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
