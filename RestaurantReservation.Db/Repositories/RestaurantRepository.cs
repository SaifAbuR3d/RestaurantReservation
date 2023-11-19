using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Db.Repositories;

public class RestaurantRepository
{
    private readonly RestaurantReservationDbContext _context;

    public RestaurantRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public Restaurant CreateRestaurant(Restaurant restaurant)
    {
        _context.Restaurants.Add(restaurant);
        _context.SaveChanges();
        return restaurant;
    }

    public Restaurant UpdateRestaurant(Restaurant restaurant)
    {
        _context.Restaurants.Update(restaurant);
        _context.SaveChanges();
        return restaurant;
    }

    public void DeleteRestaurant(int restaurantId)
    {
        var restaurant = _context.Restaurants.Find(restaurantId);
        if (restaurant != null)
        {
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
        }
    }
}