using Server.DTO.WorkTask;

namespace Server.DTO.Project
{
    public class ProjectDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string ClientName { get; set; } = "";
        public List<WorkTaskDTO> WorkTasks { get; set; } = new();
    }
}
