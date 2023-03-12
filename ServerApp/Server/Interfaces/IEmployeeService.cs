using Model;

namespace Server.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee?> Get(long id);
        Task Add(Employee task);
        Task Update(long id,Employee entity);
        Task Delete(long id);
        Task<List<Employee?>> GetBest5();
    }
}
