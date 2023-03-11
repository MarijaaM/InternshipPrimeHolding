using AutoMapper;
using InternshipPrimeHolding.DTO;
using InternshipPrimeHolding.Interfaces;
using Model;

namespace InternshipPrimeHolding.Services
{
    public class CustomMapperService : ICustomMapperService
    {
        private readonly IMapper _mapper;

        public CustomMapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public EmployeeDTO MapEmpoloyee(Employee? employee)
        {
            EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(employee);
            for (int i = 0; i < employeeDTO.WorkTasks.Count; i++)
            {
                employeeDTO.WorkTasks[i].State = employee?.WorkTasks[i].States.FirstOrDefault()?.State;
            }
            return employeeDTO;
        }
    }
}
