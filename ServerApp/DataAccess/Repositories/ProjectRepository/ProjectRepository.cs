using DataAccess.Infrastructure;
using Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.ProjectRepository;

public class ProjectRepository : IProjectRepository
{
    private DatabaseContext _databaseContext;
    public ProjectRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public async Task Add(Project project)
    {
        _databaseContext.Projects.Add(project);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        Project? project = await Get(id) 
            ?? throw new BadRequestException($"Project with id: {id} does not exist");
        _databaseContext.Projects.Remove(project);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<Project?> Get(long id)
    {
        return await _databaseContext.Projects
                        .Include(x => x.WorkTasks)
                        .ThenInclude(x => x.States)
                        .Include(x=>x.WorkTasks)
                        .ThenInclude(x=>x.Assignee)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Project>> GetAll()
    {
        return await _databaseContext.Projects
                        .Include(x => x.WorkTasks)
                        .ThenInclude(x => x.States)
                        .ToListAsync();
    }

    public async Task Update(long id, Project project)
    {
        Project? existingProject = await Get(id) 
            ?? throw new BadRequestException($"Project with id: {id} does not exist");
        existingProject.Name = project.Name; 
        existingProject.Description = project.Description;
        existingProject.ClientName = project.ClientName; 

        await _databaseContext.SaveChangesAsync();
    }


}
