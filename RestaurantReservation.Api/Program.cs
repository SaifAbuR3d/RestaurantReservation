using FluentValidation.AspNetCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Db.Repositories.RepositoryInterface;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddJsonOptions(opt =>
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles)
                .AddNewtonsoftJson(opt =>
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


builder.Services.AddControllers()
            .AddFluentValidation(v =>
            {
                v.ImplicitlyValidateChildProperties = true;
                v.ImplicitlyValidateRootCollectionElements = true;
                v.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(_ =>
new RestaurantReservationDbContext(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>(); 
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
