using DataAccess.Repositories.EmployeeRepository;
using DataAccess.Repositories.TaskStateHistoyRepository;
using DataAccess.Repositories.WorkTaskRepository;
using Server.Interfaces;
using Model;
using Server.DTO.WorkTask;

namespace Server.Services;

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
        if (await _workTaskRepository.Get(workTaskId) == null)
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
    public async Task<List<WorkTaskStats>> GetWorkTaskStats()
    {
        DateTime date = DateTime.Now.AddYears(-1);
        List<WorkTaskStats> stats = new();
        for (int i = 0; i < 12; i++)
        {
            DateTime from = new DateTime(date.Year, date.Month, 1);
            DateTime to = new DateTime(date.Year, (date.Month % 12) + 1, 1);
            var result = await _taskStateHistoryRepository.GetTaskRecordsByDate(from, to);
            List<StatsRecord> statsRecords = new()
            {
                new StatsRecord(TaskState.ToDo, result.Where(x => x.State == TaskState.ToDo).Count()),
                new StatsRecord(TaskState.InProgress, result.Where(x => x.State == TaskState.InProgress).Count()),
                new StatsRecord(TaskState.InQA, result.Where(x => x.State == TaskState.InQA).Count()),
                new StatsRecord(TaskState.Done, result.Where(x => x.State == TaskState.Done).Count())
            };
            
            stats.Add(new()
            {
                Month = date.ToString("MMMM yyyy"),
                StatsRecords = statsRecords
            });

            date = date.AddMonths(1);
        }
        return stats;

    }
}
