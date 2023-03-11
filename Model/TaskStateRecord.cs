
namespace Model;

public class TaskStateRecord
{
    public long Id { get; set; }
    public long WorkTaskId { get; set; } 
    public TaskState State { get; set; }
    public DateTime Timestamp { get; set; }
    public WorkTask? WorkTask { get; set; }
    
}
