using AutoMapper;
using InternshipPrimeHolding.DTO;
using InternshipPrimeHolding.Model;

namespace InternshipPrimeHolding.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee,AddEmployeeDTO>().ReverseMap();
            CreateMap<Employee,SimpleEmployeeDTO>().ReverseMap();

            CreateMap<WorkTask, WorkTaskDTO>().ReverseMap();
            CreateMap<WorkTask,AddWorkTaskDTO>().ReverseMap();
            CreateMap<WorkTask,SimpleWorkTaskDTO>().ReverseMap();
            
        }
    }
}
