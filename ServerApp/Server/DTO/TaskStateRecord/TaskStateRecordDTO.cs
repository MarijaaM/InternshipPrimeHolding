using Model;
using System.Text.Json.Serialization;

namespace Server.DTO.TaskStateRecord;

public class TaskStateRecordDTO
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TaskState State { get; set; }
    public DateTime Timestamp { get; set; }
}
