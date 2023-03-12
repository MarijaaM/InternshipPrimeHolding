namespace Model;

public class Employee
{
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PhoneNumber { get; set; } = "";
    public DateTime DateOfBirth { get; set; }
    public decimal MonthlySalary { get; set; }
    public long Id { get; set; }
    public List<WorkTask> WorkTasks { get; set; }=new List<WorkTask>();
}
