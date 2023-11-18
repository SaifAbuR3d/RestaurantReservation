using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db.Repositories;

var configuration = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json")
  .Build();

string connectionString = configuration.GetSection("constr").Value;

using (var context = new RestaurantReservationDbContext(connectionString))
{
    var customerRepository = new CustomerRepository(context);

    //var query = from r in context.Restaurants
    //            where context.CalculateTotalRevenue(r.RestaurantId) > 100
    //            select r;

    //foreach (var item in query)
    //{
    //    Console.WriteLine(item.RestaurantId);
    //}

    foreach(var customer in customerRepository.FindCustomersWithPartySizeGreaterThan(0))
    {
        Console.WriteLine(customer.FirstName);
    }

}
