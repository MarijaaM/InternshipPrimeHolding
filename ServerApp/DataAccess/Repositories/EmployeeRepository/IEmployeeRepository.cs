using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAll();
        Task<Employee?> Get(long id);
        Task Add(Employee employee);
        Task Update(long id, Employee employee);
        Task Delete(long id);
    }
}
