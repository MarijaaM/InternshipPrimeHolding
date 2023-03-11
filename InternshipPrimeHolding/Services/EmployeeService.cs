using DataAccess.Repositories.EmployeeRepository;
using InternshipPrimeHolding.Interfaces;
using InternshipPrimeHolding.Model;

namespace InternshipPrimeHolding.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<bool> Add(Employee task)
        {
            return _employeeRepository.Add(task);
        }

        public Task<bool> Delete(long id)
        {
            return _employeeRepository.Delete(id);
        }

        public Task<Employee?> Get(long id)
        {
            return _employeeRepository.Get(id);
        }

        public Task<List<Employee>> GetAll()
        {
            return _employeeRepository.GetAll();
        }

        public Task<bool> Update(long id,Employee entity)
        {
           return _employeeRepository.Update(id, entity);
        }
    }
}
