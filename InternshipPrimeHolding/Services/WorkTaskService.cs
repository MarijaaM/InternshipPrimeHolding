using DataAccess.Repositories.EmployeeRepository;
using DataAccess.Repositories.TaskStateHistoyRepository;
using DataAccess.Repositories.WorkTaskRepository;
using InternshipPrimeHolding.Interfaces; 
using Model;
namespace InternshipPrimeHolding.Services;

public class WorkTaskService : IWorkTaskService
{
    private readonly IWorkTaskRepository _workTaskRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ITaskStateHistoryRepository _taskStateHistoryRepository;

    public WorkTaskService(IWorkTaskRepository workTaskRepository, IEmployeeRepository employeeRepository, ITaskStateHistoryRepository taskStateHistoryRepository)
    {
        _workTaskRepository = workTaskRepository;
        _employeeRepository = employeeRepository;
        _taskStateHistoryRepository = taskStateHistoryRepository;
    }

    public async Task Add(WorkTask task)
    {
        await _workTaskRepository.Add(task);
        TaskStateRecord newState = new()
        {
            Timestamp = DateTime.Now,
            State = TaskState.ToDo,
            WorkTaskId = task.Id
        };
        await _taskStateHistoryRepository.Add(newState);
    }

    public async Task Assign(long workTaskId, long employeeId)
    {
        Employee? employee = await _employeeRepository.Get(employeeId)
            ?? throw new BadRequestException($"Employee with id: {employeeId} does not exist");

        WorkTask? workTask = await Get(workTaskId)
            ?? throw new BadRequestException($"Task with id: {workTaskId} does not exist");

        workTask.AssigneeId = employeeId;
        await Update(workTaskId, workTask);
    }

    public async Task ChangeState(long workTaskId, TaskState taskState)
    { 
        TaskStateRecord? currentTaskState = await _taskStateHistoryRepository.Get(workTaskId);
        if(await _workTaskRepository.Get(workTaskId)==null)
            throw new BadRequestException($"Task with id {workTaskId} does not exist");


        if (currentTaskState?.State == taskState)
            throw new BadRequestException($"Task with id {workTaskId} is already in state: {taskState}");
         
        TaskStateRecord newState = new()
        {
            Timestamp = DateTime.Now,
            State = taskState,
            WorkTaskId = workTaskId
        };
        await _taskStateHistoryRepository.Add(newState); 
    }

    public async Task Delete(long id)
    {
        await _workTaskRepository.Delete(id);
    }

    public Task<WorkTask?> Get(long id)
    {
        return _workTaskRepository.Get(id);
    }

    public Task<List<WorkTask>> GetAll()
    {
        return _workTaskRepository.GetAll();
    }

    public async Task Update(long id, WorkTask entity)
    {
        await _workTaskRepository.Update(id, entity);
    }
}
