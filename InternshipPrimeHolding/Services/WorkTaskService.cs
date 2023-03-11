using DataAccess.Repositories.EmployeeRepository;
using DataAccess.Repositories.WorkTaskRepository;
using InternshipPrimeHolding.Interfaces;
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

    public async Task Add(WorkTask task)
    {
        await _workTaskRepository.Add(task);
    }

    public async Task Assign(long workTaskId, long employeeId)
    {
        Employee? employee = await _employeeRepository.Get(employeeId)
            ?? throw new BadRequestException($"Employee with id: {employeeId} does not exsist");

        WorkTask? workTask = await Get(workTaskId)
            ?? throw new BadRequestException($"Task with id: {workTaskId} does not exsist");

        workTask.AssigneeId = employeeId;
        await Update(workTaskId, workTask);
    }

    public async Task ChangeState(long workTaskId, TaskState taskState)
    {
        //TODO
        WorkTask? workTask = await Get(workTaskId);
        if (workTask != null)
        {
            /*  if (workTask.State != taskState)
              {
                  workTask.State = taskState;
                  return await Update(workTaskId, workTask);
              } */
        }
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
