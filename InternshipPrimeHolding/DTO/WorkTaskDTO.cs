using Model; 

namespace InternshipPrimeHolding.DTO
{
    public class WorkTaskDTO
    {
        public long Id { get; set; } 
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DueDate { get; set; }
        public TaskState State { get; set; }
        public virtual SimpleEmployeeDTO? Assignee { get; set; }
    }
}
