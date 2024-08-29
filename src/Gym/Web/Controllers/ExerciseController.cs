using Application.Interfaces;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;
        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet("Get")]
        public IActionResult GetAllExercise()
        {
            return Ok(_exerciseService.GetAllExercise());
        }

        [HttpGet("GetByCategory/{category}")]
        public IActionResult GetExerciseByCategory(Category category)
        {
            return Ok(_exerciseService.GetExerciseByCategory(category));
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetExerciseById(int id)
        {
            try
            {
                return Ok(_exerciseService.GetExerciseById(id));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

