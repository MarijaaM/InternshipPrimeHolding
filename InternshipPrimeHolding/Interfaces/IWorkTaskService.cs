using Model;

namespace InternshipPrimeHolding.Interfaces
{
    public interface IWorkTaskService
    {
        Task<List<WorkTask>> GetAll();
        Task<WorkTask?> Get(long id);
        Task Add(WorkTask task);
        Task Update(long id, WorkTask entity);
        Task Delete(long id);
        Task Assign(long workTaskId, long employeeId);
        Task ChangeState(long workTaskId, TaskState taskState);
    }
}
