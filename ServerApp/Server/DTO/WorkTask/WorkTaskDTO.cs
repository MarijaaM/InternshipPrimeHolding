using Server.DTO.Employee;
using Server.DTO.TaskStateRecord;
using Model;
using Server.DTO.Project;
using System.Text.Json.Serialization;

namespace Server.DTO.WorkTask
{
    public class WorkTaskDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DueDate { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TaskState? State { get; set; }
        public virtual SimpleEmployeeDTO? Assignee { get; set; }
        public List<TaskStateRecordDTO> States { get; set; } = new(); 
    }
}
