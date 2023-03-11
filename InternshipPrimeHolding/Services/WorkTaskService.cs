using DataAccess.Repositories.EmployeeRepository; 
using DataAccess.Repositories.WorkTaskRepository;
using InternshipPrimeHolding.Interfaces;
using InternshipPrimeHolding.Model;
using Model;

namespace InternshipPrimeHolding.Services;

public class WorkTaskService : IWorkTaskService
{
    private readonly IWorkTaskRepository _workTaskRepository;
    private readonly IEmployeeRepository _employeeRepository;

    public WorkTaskService(IWorkTaskRepository workTaskRepository, IEmployeeRepository employeeRepository)
    {
        _workTaskRepository = workTaskRepository;
        _employeeRepository = employeeRepository;
    }

    public Task<bool> Add(WorkTask task)
    {
        return _workTaskRepository.Add(task);
    }

    public async Task<bool> Assign(long workTaskId, long employeeId)
    {
        Employee? employee = await _employeeRepository.Get(employeeId);
        WorkTask? workTask = await Get(workTaskId);
        if (employee != null && workTask != null)
        {
            workTask.AssigneeId = employeeId;
            return await Update(workTaskId, workTask);
        }
        return false;
    }

    public async Task<bool> ChangeState(long workTaskId, TaskState taskState)
    {
        WorkTask? workTask = await Get(workTaskId);
        if (workTask != null)
        {
            if (workTask.State != taskState)
            {
                workTask.State = taskState;
                return await Update(workTaskId, workTask);
            }
            if(taskState==TaskState.Done)
            {
                workTask.TaskDone = DateTime.Now;
            }
        }
        return false;
    }

    public Task<bool> Delete(long id)
    {
        return _workTaskRepository.Delete(id);
    }

    public Task<WorkTask?> Get(long id)
    {
        return _workTaskRepository.Get(id);
    }

    public Task<List<WorkTask>> GetAll()
    {
        return _workTaskRepository.GetAll();
    }

    public Task<bool> Update(long id, WorkTask entity)
    {
        return _workTaskRepository.Update(id, entity);
    }
}
