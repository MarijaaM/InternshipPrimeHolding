using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.ProjectRepository
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project?> Get(long id);
        Task Add(Project project);
        Task Update(long id, Project project);
        Task Delete(long id);
    }
}
