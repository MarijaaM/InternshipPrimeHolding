using InternshipPrimeHolding.DTO;
using InternshipPrimeHolding.Model;

namespace InternshipPrimeHolding.Interfaces
{
    public interface IValidatorService
    {
        bool ValidateEmployee(AddEmployeeDTO employee);
        bool ValidateWorkTask(AddWorkTaskDTO workTask);
    }
}
