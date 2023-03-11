using InternshipPrimeHolding.DTO;
using Model;

namespace InternshipPrimeHolding.Interfaces
{
    public interface IValidatorService
    {
        bool ValidateEmployee(AddEmployeeDTO employee);
        bool ValidateWorkTask(AddWorkTaskDTO workTask);
    }
}
