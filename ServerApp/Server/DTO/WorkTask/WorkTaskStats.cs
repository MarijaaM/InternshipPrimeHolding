namespace Server.DTO.WorkTask
{
    public class WorkTaskStats
    {
        public string Month { get; set; } = "";
        public List<StatsRecord> StatsRecords { get; set; } = new();
    }
}
