﻿
namespace Model;

public class WorkTask
{
    public string Title { get; set; } = "";

    public string Description { get; set; } = "";
    public virtual Employee? Assignee { get; set; }
    public long? AssigneeId { get; set; }
    public DateTime DueDate { get; set; }
    public long Id { get; set; }
    public List<TaskStateRecord> States { get; set; } = new();

    public Project? Project { get; set; } 
    public long ProjectId { get; set; } 

}
