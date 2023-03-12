using DataAccess.Infrastructure;
using Microsoft.EntityFrameworkCore;
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

    public async Task<TaskStateRecord?> Get(long workTaskId)
    {
        return await _databaseContext.TaskStateHistory
                    .OrderByDescending(x => x.Timestamp)
                    .FirstOrDefaultAsync(x => x.WorkTaskId == workTaskId);
    }

    public async Task<List<TaskStateRecord>> GetFinishedTaskRecords(DateTime from, DateTime to)
    {
        return await _databaseContext.TaskStateHistory
                                .Include(x => x.WorkTask)
                                .ThenInclude(x => x.Assignee)
                                .Where(x => x.Timestamp > from
                                            && x.Timestamp < to
                                            && x.State == TaskState.Done
                                            && x.WorkTask != null
                                            && x.WorkTask.AssigneeId != null) 
                                .ToListAsync();
    }
    public async Task<List<TaskStateRecord>> GetTaskRecordsByDate(DateTime from, DateTime to)
    {
        return await _databaseContext.TaskStateHistory
                                .Include(x => x.WorkTask)
                                .Where(x => x.Timestamp > from
                                            && x.Timestamp < to) 
                                .ToListAsync();
    }
}
