using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.WorkTaskRepository;

public interface IWorkTaskRepository : IRepository<WorkTask>
{
    Task Delete(long id);
}
