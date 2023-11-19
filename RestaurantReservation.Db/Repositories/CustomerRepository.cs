using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CustomerExistsAsync(int id)
    {
        return await _context.Customers.AnyAsync(c => c.CustomerId == id);
    }
    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetCustomerAsync(int id, bool includeReservations = false)
    {
        if (includeReservations)
        {
            return await _context.Customers.Include(c => c.Reservations).FirstOrDefaultAsync(c => c.CustomerId == id);
        }
        return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
    }

    public Customer CreateCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        return customer;
    }

    public Customer UpdateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);
        return customer;
    }

    public void DeleteCustomer(Customer customer)
    {
        _context.Customers.Remove(customer);
    }

    //public void AddReservation(int customerId, Reservation reservation)
    //{
    //    var customer = _context.Customers.Find(customerId);
    //    if (customer != null)
    //    {
    //        customer.Reservations.Add(reservation);
    //    }
    //}

    public List<Customer> FindCustomersWithPartySizeGreaterThan(int partySize)
    {
        return _context.Customers
            .FromSqlRaw("EXEC FindCustomersWithPartySizeGreaterThan {0}", partySize).ToList();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}
