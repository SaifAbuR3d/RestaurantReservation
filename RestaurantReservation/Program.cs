using Microsoft.Extensions.Configuration;
using RestaurantReservation.Db;

var configuration = new ConfigurationBuilder()
  .AddJsonFile("appsettings.json")
  .Build();

string connectionString = configuration.GetSection("constr").Value;

var context = new RestaurantReservationDbContext(connectionString);