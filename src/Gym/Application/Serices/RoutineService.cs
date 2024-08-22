using Application.Common;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Domain.Interfaces;


namespace Application.Serices
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
            var newRoutine = _mapper.Map<Routine>(routineDto);
            _routineRepository.CreateRoutine(newRoutine);
            return _operationResultService.CreateSuccessResult("Routine Created");
        }
        public RoutineDto GetRoutineById(int routineId)
        {
            var getRoutine = _routineRepository.GetRoutineById(routineId);
            return _mapper.Map<RoutineDto>(getRoutine);
        }

        public bool DeleteRoutine(int routineId)
        {
            var routine = _routineRepository.GetRoutineById(routineId);
            if (routine != null)
            {
                _routineRepository.DeleteRoutine(routine);
                return true;
            }
            return false;
        }

        public IEnumerable<RoutineReadDto> GetAllRoutine()
        {
             var routine = _routineRepository.GetAllRoutine();
            return _mapper.Map<IEnumerable<RoutineReadDto>>(routine);
        }

        public IEnumerable<RoutineDto> GetRoutineForDifficulty(Difficulty difficulty)
        { 
            var routine = _routineRepository.GetRoutineForDifficulty(difficulty);
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
