using Model;

namespace InternshipPrimeHolding.DTO
{
    public class AddEmployeeDTO
    {
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public decimal MonthlySalary { get; set; }
    }
}
