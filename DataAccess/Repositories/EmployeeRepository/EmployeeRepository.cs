using DataAccess.Infrastructure;
using Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories.EmployeeRepository;

public class EmployeeRepository : IEmployeeRepository
{
    private DatabaseContext _databaseContext;
    public EmployeeRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public async Task Add(Employee employee)
    {
        _databaseContext.Employees.Add(employee);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        Employee? employee = await Get(id);
        if (employee == null)
        {
            throw new BadRequestException($"Employee with id: {id} does not exsist");
        }
        _databaseContext.Employees.Remove(employee);
        await _databaseContext.SaveChangesAsync();
    }

    public async Task<Employee?> Get(long id)
    {
        return await _databaseContext.Employees
                        .Include(x => x.WorkTasks)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Employee>> GetAll()
    {
        return await _databaseContext.Employees
                        .Include(x => x.WorkTasks)
                        .ToListAsync();
    }

    public async Task Update(long id, Employee employee)
    {
        Employee? e = await Get(id);
        if (e == null)
        {
            throw new BadRequestException($"Employee with id: {id} does not exsist");
        }
        e.FullName = employee.FullName;
        e.WorkTasks = employee.WorkTasks;
        e.PhoneNumber = employee.PhoneNumber;
        e.Email = employee.Email;
        e.DateOfBirth = employee.DateOfBirth;
        e.MonthlySalary = employee.MonthlySalary;

        await _databaseContext.SaveChangesAsync();
    }


}
