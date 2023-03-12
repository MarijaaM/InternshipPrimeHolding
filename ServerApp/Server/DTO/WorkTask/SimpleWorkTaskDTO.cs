using Model;
using System.Text.Json.Serialization;

namespace Server.DTO.WorkTask
{
    public class SimpleWorkTaskDTO
    {
        public long Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DueDate { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TaskState? State { get; set; }
    }
}
