using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Contracts.RepositoryInterface;

public interface IEmployeeRepository
{
    Employee CreateEmployee(Employee employee);
    void DeleteEmployee(Employee employee);
    Task<bool> EmployeeExistsAsync(int id);
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
    Task<decimal?> GetAverageOrderAmountAsync(int employeeId);
    Task<Employee?> GetEmployeeAsync(int employeeId, bool includeOrders = false);
    Task<IEnumerable<Employee>> GetManagers();
    Task<bool> SaveChangesAsync();
}