using DataAccess.Infrastructure;
using Model;

namespace DataAccess.Repositories.TaskStateHistoyRepository;

public class TaskStateHistoryRepository : ITaskStateHistoryRepository
{
    private readonly DatabaseContext _databaseContext;

    public TaskStateHistoryRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task Add(TaskStateRecord taskState)
    {
        _databaseContext.TaskStateHistory.Add(taskState);
        await _databaseContext.SaveChangesAsync();
    }


    public Task<TaskStateRecord?> Get(long id)
    {
        //TODO
        throw new NotImplementedException();
    }

    public Task<List<TaskStateRecord>> GetAll()
    {
        //TODO
        throw new NotImplementedException();
    }

    public Task Update(long id, TaskStateRecord entity)
    {
        //TODO
        throw new NotImplementedException();
    }
}
