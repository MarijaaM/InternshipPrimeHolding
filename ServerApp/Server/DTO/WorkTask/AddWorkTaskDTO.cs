using Model;

namespace Server.DTO.WorkTask
{
    public class AddWorkTaskDTO
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DueDate { get; set; }
        public long ProjectId { get; set; }
    }
}
