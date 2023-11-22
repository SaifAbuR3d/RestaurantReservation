using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Contracts.RepositoryInterface;

public interface IReservationRepository
{
    Reservation CreateReservation(Reservation reservation);
    void DeleteReservation(Reservation reservation);
    Task<IEnumerable<Reservation>> GetAllReservationsAsync();
    Task<Reservation?> GetReservationAsync(int reservationId, bool includeOrders = false);
    Task<IEnumerable<Reservation>> GetReservationsByCustomerIdAsync(int customerId);
    Task<bool> ReservationExistsAsync(int reservationId);
    Task<bool> SaveChangesAsync();
}