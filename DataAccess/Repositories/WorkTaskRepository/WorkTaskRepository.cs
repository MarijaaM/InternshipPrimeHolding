using DataAccess.Infrastructure;
using InternshipPrimeHolding.Model;
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

    public async Task<bool> Add(WorkTask task)
    {
        _databaseContext.WorkTasks.Add(task);
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return true;
    }


    public async Task<bool> Delete(long id)
    {
        WorkTask? workTask = await Get(id);
        if (workTask == null)
        {
            return false;
        }
        _databaseContext.WorkTasks.Remove(workTask);
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return true;
    }

    public async Task<WorkTask?> Get(long id)
    {
        return await _databaseContext.WorkTasks.Include(x => x.Assignee).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<WorkTask>> GetAll()
    {
        return await _databaseContext.WorkTasks.Include(x => x.Assignee).ToListAsync();
    }

    public async Task<bool> Update(long id, WorkTask workTask)
    {
        WorkTask? wt = await Get(id);
        if (wt == null)
        {
            return false;
        }
        wt.Title = workTask.Title;
        wt.Description = workTask.Description;
        wt.DueDate = workTask.DueDate;
        wt.Assignee = workTask.Assignee;
        wt.State = workTask.State;
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return true;
    }
}
