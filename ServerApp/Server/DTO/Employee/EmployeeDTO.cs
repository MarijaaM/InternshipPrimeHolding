﻿using Server.DTO.WorkTask;
using Model;

namespace Server.DTO.Employee
{
    public class EmployeeDTO
    {
        public long Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public decimal MonthlySalary { get; set; }
        public List<SimpleWorkTaskDTO> WorkTasks { get; set; } = new();
    }
}
