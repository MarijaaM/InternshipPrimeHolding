using InternshipPrimeHolding.DTO;
using InternshipPrimeHolding.Interfaces;
using InternshipPrimeHolding.Model;

namespace InternshipPrimeHolding.Services
{
    public class ValidatorService : IValidatorService
    {
        public ValidatorService() { }
        public bool ValidateEmployee(AddEmployeeDTO employee)
        {
            return !string.IsNullOrWhiteSpace(employee.FullName)
                && !string.IsNullOrWhiteSpace(employee.PhoneNumber)
                && employee.MonthlySalary > 0
                && employee.DateOfBirth < DateTime.Now;
        }
        public bool ValidateWorkTask(AddWorkTaskDTO workTask)
        {
            return !string.IsNullOrWhiteSpace(workTask.Title)
                && !string.IsNullOrWhiteSpace(workTask.Description)
                && workTask.DueDate > DateTime.Now;
        }
    }
}
