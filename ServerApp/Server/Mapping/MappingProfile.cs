using AutoMapper;
using Server.DTO.Employee;
using Server.DTO.Project;
using Server.DTO.TaskStateRecord;
using Server.DTO.WorkTask;
using Model;

namespace Server.Mapping
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

            CreateMap<TaskStateRecord, TaskStateRecordDTO>().ReverseMap();
            
            CreateMap<Project, ProjectDTO>().ReverseMap();
            CreateMap<Project, SimpleProjectDTO>().ReverseMap();
            CreateMap<Project, AddProjectDTO>().ReverseMap();
            
        }
    }
}
