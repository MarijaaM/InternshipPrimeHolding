using DataAccess.Infrastructure;
using Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.WorkTaskRepository;

public class WorkTaskRepository : IWorkTaskRepository
{
    private DatabaseContext _databaseContext;
    public WorkTaskRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task Add(WorkTask task)
    {
        _databaseContext.WorkTasks.Add(task);
        await _databaseContext.SaveChangesAsync();

    }


    public async Task Delete(long id)
    {
        WorkTask? workTask = await Get(id);
        if (workTask == null)
        {
            throw new BadRequestException($"Task with id: {id} does not exsist");
        }
        _databaseContext.WorkTasks.Remove(workTask);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<WorkTask?> Get(long id)
    {
        return await _databaseContext.WorkTasks
                        .Include(x => x.Assignee)
                        .Include(x => x.States)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<WorkTask>> GetAll()
    {
        return await _databaseContext.WorkTasks.Include(x => x.Assignee).ToListAsync();
    }

    public async Task Update(long id, WorkTask workTask)
    {
        WorkTask? wt = await Get(id);
        if (wt == null)
        {
            throw new BadRequestException($"Task with id: {id} does not exsist");
        }
        wt.Title = workTask.Title;
        wt.Description = workTask.Description;
        wt.DueDate = workTask.DueDate;
        wt.Assignee = workTask.Assignee;
        await _databaseContext.SaveChangesAsync();
    }
}
