using Model;

namespace InternshipPrimeHolding.DTO
{
    public class AddWorkTaskDTO
    {
        public string Title { get; set; } = ""; 
        public string Description { get; set; } = "";
        public DateTime DueDate { get; set; }
    }
}
