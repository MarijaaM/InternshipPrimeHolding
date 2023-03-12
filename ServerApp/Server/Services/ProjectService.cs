using DataAccess.Repositories.EmployeeRepository;
using DataAccess.Repositories.ProjectRepository;
using DataAccess.Repositories.TaskStateHistoyRepository;
using Server.Interfaces;
using Model;

namespace Server.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public Task Add(Project project)
        {
            return _projectRepository.Add(project);
        }

        public Task Delete(long id)
        {
            return _projectRepository.Delete(id);
        }

        public async Task<Project?> Get(long id)
        {
            Project? project = await _projectRepository.Get(id);
            project?.WorkTasks.ForEach(x =>
                x.States = x.States.OrderByDescending(x => x.Timestamp).ToList());
            return project;
        }

        public async Task<List<Project>> GetAll()
        {
            List<Project>? projects = await _projectRepository.GetAll();
            foreach (var project in projects)
            { 
                project?.WorkTasks.ForEach(x =>
                    x.States = x.States.OrderByDescending(x => x.Timestamp).ToList());
            }
            return projects;
        } 

        public async Task Update(long id, Project project)
        {
            await _projectRepository.Update(id, project);
        }
    }
}
