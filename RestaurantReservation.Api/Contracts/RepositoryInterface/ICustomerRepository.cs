using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Contracts.RepositoryInterface;

public interface ICustomerRepository
{
    Customer CreateCustomer(Customer customer);
    Task<bool> CustomerExistsAsync(int id);
    void DeleteCustomer(Customer customer);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerAsync(int id, bool includeReservations = false);
    Task<bool> SaveChangesAsync();
}