using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Repositories.RepositoryInterface;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly RestaurantReservationDbContext _context;

    public ReservationRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ReservationExistsAsync(int reservationId)
    {
        return await _context.Reservations.AnyAsync(r => r.ReservationId == reservationId);
    }

    public async Task<IEnumerable<Reservation>> GetAllReservationsAsync()
    {
        return await _context.Reservations.ToListAsync();
    }

    public async Task<Reservation?> GetReservationAsync(int reservationId, bool includeOrders = false)
    {
        if (includeOrders)
        {
            return await _context.Reservations
                .Include(r => r.Orders)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);
        }
        return await _context.Reservations
                     .FirstOrDefaultAsync(r => r.ReservationId == reservationId);
    }

    public async Task<IEnumerable<Reservation>> GetReservationsByCustomerIdAsync(int customerID)
    {
        return await _context.Reservations
            .Where(r => r.CustomerId == customerID)
            .ToListAsync();
    }
    public Reservation CreateReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        return reservation;
    }

    public void DeleteReservation(Reservation reservation)
    {
        _context.Reservations.Remove(reservation);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() >= 0);
    }
}
