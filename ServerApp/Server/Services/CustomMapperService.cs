using AutoMapper;
using Server.DTO.Employee;
using Server.Interfaces;
using Model;
using Server.DTO.Project;
using Server.DTO.WorkTask;
using System.Threading.Tasks;

namespace Server.Services
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

        public ProjectDTO MapProject(Project project)
        {
            ProjectDTO projectDTO = _mapper.Map<ProjectDTO>(project);
            for (int i = 0; i < projectDTO.WorkTasks.Count; i++)
            {
                projectDTO.WorkTasks[i].State = project?.WorkTasks[i].States.FirstOrDefault()?.State;
            }
            return projectDTO;
        }
        public WorkTaskDTO MapWorkTask(WorkTask? workTask)
        {
            WorkTaskDTO tasksDTO = _mapper.Map<WorkTaskDTO>(workTask);

            tasksDTO.State = workTask.States.OrderByDescending(x=>x.Timestamp).FirstOrDefault()?.State;
            return tasksDTO;
        }
    }
}
