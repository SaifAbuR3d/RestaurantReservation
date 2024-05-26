using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories.RepositoryInterface;

public interface ICustomerRepository
{
    Customer CreateCustomer(Customer customer);
    Task<bool> CustomerExistsAsync(int id);
    void DeleteCustomer(Customer customer);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerAsync(int id, bool includeReservations = false);
    Task<bool> SaveChangesAsync();
}