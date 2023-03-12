using Server.DTO.Employee;
using Model;
using Server.DTO.Project;
using Server.DTO.WorkTask;

namespace Server.Interfaces
{
    public interface ICustomMapperService
    {
        EmployeeDTO MapEmpoloyee(Employee? employee);
        ProjectDTO MapProject(Project project);
        WorkTaskDTO MapWorkTask(WorkTask? workTask);
    }
}
