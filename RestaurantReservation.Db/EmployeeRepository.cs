using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain;
using Microsoft.IdentityModel.Tokens;

namespace RestaurantReservation.Db
{
    public class EmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public Employee CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee? UpdateEmployeePosition(int employeeId, string newPosition)
        {
            var employee = _context.Employees.Find(employeeId); 
            if (employee != null) 
            { 
                employee.Position = newPosition;
                _context.SaveChanges();
            }
            return employee;
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public List<Employee> ListManagers()
        {
            return _context.Employees
                .Where(e => e.Position == "Manager")
                .ToList();
        }

        public decimal CalculateAverageOrderAmount(int employeeId)
        {
            var employee = _context.Employees
                .Include(e => e.Orders)
                .FirstOrDefault(e => e.EmployeeId == employeeId);

            if (employee == null)
            {
                return -1.0m; 
            }
            if (employee.Orders.IsNullOrEmpty())
            {
                return 0.0m; 
            }

            return employee.Orders.Average(o => o.TotalAmount); 
        }
    }
}