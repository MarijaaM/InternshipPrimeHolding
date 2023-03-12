using Model;

namespace DataAccess.Repositories.WorkTaskRepository;

public interface IWorkTaskRepository
{
    Task<List<WorkTask>> GetAll(); 
    Task<WorkTask?> Get(long id);
    Task Add(WorkTask task);
    Task Update(long id, WorkTask entity);
    Task Delete(long id);
}
