using Model;
using System.Text.Json.Serialization;

namespace Server.DTO.WorkTask
{
    public class StatsRecord
    {
        public StatsRecord(TaskState state, int count)
        {
            State = state;
            Count = count;
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TaskState State { get; set; }
        public int Count { get; set; }
    }
}