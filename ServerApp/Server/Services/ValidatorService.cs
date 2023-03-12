using Server.DTO.Employee;
using Server.DTO.WorkTask;
using Server.Interfaces;
using Model;
using Server.DTO.Project;

namespace Server.Services
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

        public bool ValidateProject(AddProjectDTO project)
        {
            return !string.IsNullOrWhiteSpace(project.Name)
               && !string.IsNullOrWhiteSpace(project.Description)
               && !string.IsNullOrWhiteSpace(project.ClientName);
        }

        public bool ValidateWorkTask(AddWorkTaskDTO workTask)
        {
            return !string.IsNullOrWhiteSpace(workTask.Title)
                && !string.IsNullOrWhiteSpace(workTask.Description)
                && workTask.DueDate > DateTime.Now;
        }
    }
}
