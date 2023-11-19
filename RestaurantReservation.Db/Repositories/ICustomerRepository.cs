using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public interface ICustomerRepository
    {
       // void AddReservation(int customerId, Reservation reservation);
        Customer CreateCustomer(Customer customer);
        Task<bool> CustomerExistsAsync(int id);
        //void DeleteCustomer(int customerId);
        void DeleteCustomer(Customer customer);
        //List<Customer> FindCustomersWithPartySizeGreaterThan(int partySize);
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerAsync(int id, bool includeReservations = false);
        Task<bool> SaveChangesAsync();
        //Customer UpdateCustomer(Customer customer);
    }
}