using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public interface IEmployeeRepository
    {
        Employee CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Task<bool> EmployeeExistsAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee?> GetEmployeeAsync(int employeeId, bool includeOrders = false);
        Task<bool> SaveChangesAsync();
    }
}