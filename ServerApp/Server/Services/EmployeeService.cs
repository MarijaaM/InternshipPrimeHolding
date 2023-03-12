using DataAccess.Repositories.EmployeeRepository;
using DataAccess.Repositories.TaskStateHistoyRepository;
using Server.Interfaces;
using Model;

namespace Server.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITaskStateHistoryRepository _taskStateHistoryRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, ITaskStateHistoryRepository taskStateHistoryRepository)
        {
            _employeeRepository = employeeRepository;
            _taskStateHistoryRepository = taskStateHistoryRepository;
        }

        public Task Add(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        public Task Delete(long id)
        {
            return _employeeRepository.Delete(id);
        }

        public async Task<Employee?> Get(long id)
        {
            Employee? employee = await _employeeRepository.Get(id);
            employee?.WorkTasks.ForEach(x =>
                x.States = x.States.OrderByDescending(x => x.Timestamp).ToList());
            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee>? employees = await _employeeRepository.GetAll();
            foreach (var employee in employees)
            {
                employee?.WorkTasks.ForEach(x =>
                    x.States = x.States.OrderByDescending(x => x.Timestamp).ToList());
            }
            return employees;
        }

        public async Task<List<Employee?>> GetBest5()
        {
            DateTime dateTime = DateTime.Now.AddMonths(0);
            DateTime from = new(dateTime.Year, dateTime.Month, 1);
            DateTime to = new(dateTime.Year, dateTime.AddMonths(1).Month, 1);
            List<TaskStateRecord> records = await _taskStateHistoryRepository.GetFinishedTaskRecords(from, to);

            List<EmployeeTaskCount> employeeTaskCounts = records.GroupBy(x => (long)x.WorkTask.AssigneeId)
                                                                .Select(x =>
                                                                    new EmployeeTaskCount()
                                                                    {
                                                                        EmployeeId = x.Key,
                                                                        TaskCount = x.Count()
                                                                    }
                                                                ).ToList();

            return employeeTaskCounts.OrderByDescending(x => x.TaskCount)
                                     .Take(5)
                                     .Select(x => Get(x.EmployeeId).Result)
                                     .ToList();
        }

        public async Task Update(long id, Employee employee)
        {
            await _employeeRepository.Update(id, employee);
        }
    }
}
