using InternshipPrimeHolding.DTO;
using InternshipPrimeHolding.Model;
using Model;
using System.Diagnostics.Eventing.Reader;

namespace InternshipPrimeHolding.Interfaces
{
    public interface IWorkTaskService
    {
        Task<List<WorkTask>> GetAll();
        Task<WorkTask?> Get(long id);
        Task<bool> Add(WorkTask task);
        Task<bool> Update(long id, WorkTask entity);
        Task<bool> Delete(long id);
        Task<bool> Assign(long workTaskId, long employeeId);
        Task<bool> ChangeState(long workTaskId, TaskState taskState);
    }
}
