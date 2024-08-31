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
        private readonly IRoutineExerciseService _routineExerciseService;
        private readonly IOperationResultService _operationResultService;
        public RoutineService(IRoutineRepository routineRepository, IMapper mapper, IRoutineExerciseService routineExerciseService, IOperationResultService operationResultService)
        {
            _routineRepository = routineRepository;
            _mapper = mapper;
            _routineExerciseService = routineExerciseService;
            _operationResultService = operationResultService;
        }
        public OperationResult CreateRoutine(RoutineDto routineDto)
        {

            var newRoutine = new Routine(routineDto.Name, routineDto.Duration, routineDto.Difficulty);
            _routineRepository.CreateRoutine(newRoutine);

            _routineExerciseService.CreateRoutineExercises(newRoutine.RoutineId, routineDto.ExercisesId);

            return _operationResultService.CreateSuccessResult("Routine Created");
        }

        public RoutineReadDto GetRoutineById(int routineId)
        {
            var routine = _routineRepository.GetRoutineById(routineId);
            if (routine == null) throw new KeyNotFoundException($"The given key '{routineId}' does not correspond to an exercise.");
            var routineDto = _mapper.Map<RoutineReadDto>(routine);
            routineDto.ExercisesId = _routineExerciseService.GetRoutineExercises(routineId);
            return routineDto;
        }

        public OperationResult DeleteRoutine(int routineId)
        {
            var routine = _routineRepository.GetRoutineById(routineId);
            if (routine != null)
            {
                _routineExerciseService.DeleteRoutineExercises(routineId);
                _routineRepository.DeleteRoutine(routine);
                return _operationResultService.CreateSuccessResult("Routine Deleted");
            }
            return _operationResultService.CreateFailureResult("The routine does not exist");
        }

        public IEnumerable<RoutineReadDto> GetAllRoutine()
        {
            var routines = _routineRepository.GetAllRoutine();
            var routineDtos = _mapper.Map<IEnumerable<RoutineReadDto>>(routines);
            foreach (var routineDto in routineDtos)
            {
                routineDto.ExercisesId = _routineExerciseService.GetRoutineExercises(routineDto.RoutineId);
            }
            return routineDtos;
        }

        public IEnumerable<RoutineReadDto> GetRoutineByDifficulty(Difficulty difficulty)
        {
            var routines = _routineRepository.GetRoutineByDifficulty(difficulty);
            var routineDtos = _mapper.Map<IEnumerable<RoutineReadDto>>(routines);
            foreach (var routineDto in routineDtos)
            {
                routineDto.ExercisesId = _routineExerciseService.GetRoutineExercises(routineDto.RoutineId);
            }
            return routineDtos;
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

            _routineExerciseService.UpdateRoutineExercises(routineId, routineDto.ExercisesId);
            _routineRepository.UpdateRoutine(routine);
            return _operationResultService.CreateSuccessResult("Review Created");
        }
    }
}
