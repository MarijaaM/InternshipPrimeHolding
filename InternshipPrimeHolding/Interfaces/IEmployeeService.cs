using InternshipPrimeHolding.Model;

namespace InternshipPrimeHolding.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee?> Get(long id);
        Task<bool> Add(Employee task);
        Task<bool> Update(long id,Employee entity);
        Task<bool> Delete(long id);
    }
}
