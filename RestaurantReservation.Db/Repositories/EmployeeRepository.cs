using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Repositories.RepositoryInterface;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context;

    public EmployeeRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> EmployeeExistsAsync(int id)
    {
        return await _context.Employees.AnyAsync(e => e.EmployeeId == id);
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeAsync(int employeeId, bool includeOrders = false)
    {
        if (includeOrders)
        {
            return await _context.Employees
                .Include(e => e.Orders)
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
    }

    public async Task<IEnumerable<Employee>> GetManagers()
    {
        return await _context.Employees
            .Where(e => e.Position == "Manager")
            .ToListAsync();
    }

    public async Task<decimal?> GetAverageOrderAmountAsync(int employeeId)
    {
        var employee = await _context.Employees
            .Include(e => e.Orders)
            .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

        if (employee == null)
        {
            return null;
        }

        if (!employee.Orders.Any())
        {
            return 0; 
        }

        var averageOrderAmount = employee.Orders
            .Average(order => order.TotalAmount);

        return averageOrderAmount;
    }

    public Employee CreateEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        return employee;
    }

    public void DeleteEmployee(Employee employee)
    {
        _context.Employees.Remove(employee);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}
