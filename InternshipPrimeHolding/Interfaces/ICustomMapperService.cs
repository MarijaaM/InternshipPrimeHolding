using InternshipPrimeHolding.DTO;
using Model;

namespace InternshipPrimeHolding.Interfaces
{
    public interface ICustomMapperService
    {
        EmployeeDTO MapEmpoloyee(Employee? employee);
    }
}
