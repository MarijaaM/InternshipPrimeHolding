using Model;

namespace InternshipPrimeHolding.Model
{
    public class WorkTask
    {
        public string Title { get; set; } = "";

        public string Description { get; set; } = "";
        public virtual Employee? Assignee { get; set; }
        public long? AssigneeId { get; set; }
        public DateTime DueDate { get; set; }
        public long Id { get; set; }
        public TaskState State { get; set; } = TaskState.ToDo;

        public DateTime? TaskDone { get; set; }
    }
}
