using Model;

namespace Server.Interfaces
{
    public interface IProjectService
    {
        Task<List<Project>> GetAll();
        Task<Project?> Get(long id);
        Task Add(Project task);
        Task Update(long id, Project entity);
        Task Delete(long id); 
    }
}
