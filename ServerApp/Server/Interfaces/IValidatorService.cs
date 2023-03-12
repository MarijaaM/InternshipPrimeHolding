using Server.DTO.Employee;
using Server.DTO.WorkTask;
using Model;
using Server.DTO.Project;

namespace Server.Interfaces
{
    public interface IValidatorService
    {
        bool ValidateEmployee(AddEmployeeDTO employee);
        bool ValidateProject(AddProjectDTO project);
        bool ValidateWorkTask(AddWorkTaskDTO workTask);
    }
}
