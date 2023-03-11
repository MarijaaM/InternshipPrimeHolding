using DataAccess.Infrastructure;
using InternshipPrimeHolding.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.EmployeeRepository;

public class EmployeeRepository : IEmployeeRepository
{
    private DatabaseContext _databaseContext;
    public EmployeeRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    public async Task<bool> Add(Employee employee)
    {
        _databaseContext.Employees.Add(employee);
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return true;
    }

    public async Task<bool> Delete(long id)
    {
        Employee? employee = await Get(id);
        if (employee == null)
        {
            return false;
        }
        _databaseContext.Employees.Remove(employee);
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return true;
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

    public async Task<bool> Update(long id, Employee employee)
    {
        Employee? e = await Get(id);
        if (e == null)
        {
            return false;
        }
        e.FullName = employee.FullName;
        e.WorkTasks = employee.WorkTasks;
        e.PhoneNumber = employee.PhoneNumber;
        e.Email = employee.Email;
        e.DateOfBirth = employee.DateOfBirth;
        e.MonthlySalary = employee.MonthlySalary;

        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch
        {
            return false;
        }
        return true;
    }


}
