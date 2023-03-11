using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Task Delete(long id);
    }
}
