using Model;

namespace DataAccess.Repositories.TaskStateHistoyRepository;

public interface ITaskStateHistoryRepository
{
    Task<TaskStateRecord?> Get(long workTaskId);
    Task Add(TaskStateRecord task);
    Task<List<TaskStateRecord>> GetFinishedTaskRecords(DateTime from, DateTime to);
}
