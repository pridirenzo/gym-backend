using Application.Common;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;


namespace Application.Services
{
    public class RoutineService : IRoutineService
    {
        private readonly IRoutineRepository _routineRepository;
        private readonly IMapper _mapper;
        private readonly IOperationResultService _operationResultService;
        public RoutineService(IRoutineRepository routineRepository, IMapper mapper, IOperationResultService operationResultService)
        {
            _routineRepository = routineRepository;
            _mapper = mapper;
            _operationResultService = operationResultService;
        }
        public OperationResult CreateRoutine(RoutineDto routineDto)
        {

            var newRoutine = new Routine(routineDto.Name, routineDto.Duration, routineDto.Difficulty);
            _routineRepository.CreateRoutine(newRoutine);

            foreach (int i in routineDto.ExercisesId)
            {
                var newRoutineExercise = new RoutineExercise(newRoutine.RoutineId, i);
                _routineRepository.CreateRoutineExcercise(newRoutineExercise);
            }
            // Crea la entidad de unión RoutineExercise para asociar la rutina y el ejercicio
            // Guarda la entidad de unión en el repositorio correspondiente

            return _operationResultService.CreateSuccessResult("Routine Created");
        }

        public RoutineDto GetRoutineById(int routineId)
        {
            var getRoutine = _routineRepository.GetRoutineById(routineId);
            return _mapper.Map<RoutineDto>(getRoutine);
        }

        public OperationResult DeleteRoutine(int routineId)
        {
            var routine = _routineRepository.GetRoutineById(routineId);
            if (routine != null)
            {
                _routineRepository.DeleteRoutine(routine);
                return _operationResultService.CreateSuccessResult("Routine Deleted");
            }
            return _operationResultService.CreateFailureResult("The routine does not exist");
        }

        public IEnumerable<RoutineReadDto> GetAllRoutine()
        {
            var routine = _routineRepository.GetAllRoutine();
            return _mapper.Map<IEnumerable<RoutineReadDto>>(routine);
        }

        public IEnumerable<RoutineDto> GetRoutineByDifficulty(Difficulty difficulty)
        {
            var routine = _routineRepository.GetRoutineByDifficulty(difficulty);
            return _mapper.Map<IEnumerable<RoutineDto>>(routine);
        }

        public OperationResult UpdateRoutine(int routineId, RoutineDto routineDto)
        {
            var routine = _routineRepository.GetRoutineById(routineId);
            if (routine == null)
            {
                return _operationResultService.CreateFailureResult("Routine Not Found");
            }
            routine.Name = routineDto.Name;
            routine.Duration = routineDto.Duration;
            routine.Difficulty = routineDto.Difficulty;

            _routineRepository.UpdateRoutine(routine);
            return _operationResultService.CreateSuccessResult("Review Created");
        }
    }
}
