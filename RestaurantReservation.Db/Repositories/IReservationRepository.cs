using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories
{
    public interface IReservationRepository
    {
        Reservation CreateReservation(Reservation reservation);
        void DeleteReservation(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllReservationsAsync();
        Task<Reservation?> GetReservationAsync(int reservationId, bool includeOrders = false);
        Task<bool> ReservationExistsAsync(int reservationId);
        Task<bool> SaveChangesAsync();
    }
}