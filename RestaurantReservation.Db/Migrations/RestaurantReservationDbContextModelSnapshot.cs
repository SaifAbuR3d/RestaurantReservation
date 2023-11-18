﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    partial class RestaurantReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RestaurantReservation.Domain.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Email = "john@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "123-456-7890"
                        },
                        new
                        {
                            CustomerId = 2,
                            Email = "jane@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            PhoneNumber = "987-654-3210"
                        },
                        new
                        {
                            CustomerId = 3,
                            Email = "michael@example.com",
                            FirstName = "Michael",
                            LastName = "Johnson",
                            PhoneNumber = "555-555-5555"
                        },
                        new
                        {
                            CustomerId = 4,
                            Email = "emily@example.com",
                            FirstName = "Emily",
                            LastName = "Williams",
                            PhoneNumber = "111-222-3333"
                        },
                        new
                        {
                            CustomerId = 5,
                            Email = "william@example.com",
                            FirstName = "William",
                            LastName = "Brown",
                            PhoneNumber = "444-444-4444"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            FirstName = "Alice",
                            LastName = "Johnson",
                            Position = "Manager",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 2,
                            FirstName = "Bob",
                            LastName = "Smith",
                            Position = "Manager",
                            RestaurantId = 2
                        },
                        new
                        {
                            EmployeeId = 3,
                            FirstName = "Charlie",
                            LastName = "Williams",
                            Position = "Waiter",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 4,
                            FirstName = "David",
                            LastName = "Brown",
                            Position = "Chef",
                            RestaurantId = 2
                        },
                        new
                        {
                            EmployeeId = 5,
                            FirstName = "Eva",
                            LastName = "Davis",
                            Position = "Chef",
                            RestaurantId = 1
                        },
                        new
                        {
                            EmployeeId = 6,
                            FirstName = "John",
                            LastName = "Davis",
                            Position = "Waiter",
                            RestaurantId = 2
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.EmployeeRestaurantDetails", b =>
                {
                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("EmployeeRestaurantDetails", (string)null);
                });

            modelBuilder.Entity("RestaurantReservation.Domain.MenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MenuItemId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("MenuItemId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            MenuItemId = 1,
                            Description = "Classic Italian pasta dish",
                            Name = "Spaghetti Bolognese",
                            Price = 12.99m,
                            RestaurantId = 1
                        },
                        new
                        {
                            MenuItemId = 2,
                            Description = "Freshly grilled salmon with lemon butter sauce",
                            Name = "Grilled Salmon",
                            Price = 17.99m,
                            RestaurantId = 2
                        },
                        new
                        {
                            MenuItemId = 3,
                            Description = "Traditional Italian pizza with tomatoes and fresh mozzarella",
                            Name = "Margherita Pizza",
                            Price = 10.99m,
                            RestaurantId = 1
                        },
                        new
                        {
                            MenuItemId = 4,
                            Description = "Juicy beef steak cooked to perfection",
                            Name = "Beef Steak",
                            Price = 19.99m,
                            RestaurantId = 2
                        },
                        new
                        {
                            MenuItemId = 5,
                            Description = "Crisp romaine lettuce, croutons, and Caesar dressing",
                            Name = "Caesar Salad",
                            Price = 8.99m,
                            RestaurantId = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("ReservationID");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderID = 1,
                            EmployeeID = 5,
                            OrderDate = new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4314),
                            ReservationID = 1,
                            TotalAmount = 36.97m
                        },
                        new
                        {
                            OrderID = 2,
                            EmployeeID = 5,
                            OrderDate = new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4346),
                            ReservationID = 1,
                            TotalAmount = 39.93m
                        },
                        new
                        {
                            OrderID = 3,
                            EmployeeID = 4,
                            OrderDate = new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4348),
                            ReservationID = 2,
                            TotalAmount = 37.98m
                        },
                        new
                        {
                            OrderID = 4,
                            EmployeeID = 4,
                            OrderDate = new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4350),
                            ReservationID = 2,
                            TotalAmount = 17.99m
                        },
                        new
                        {
                            OrderID = 5,
                            EmployeeID = 5,
                            OrderDate = new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4352),
                            ReservationID = 3,
                            TotalAmount = 12.99m
                        },
                        new
                        {
                            OrderID = 6,
                            EmployeeID = 4,
                            OrderDate = new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4354),
                            ReservationID = 4,
                            TotalAmount = 35.98m
                        },
                        new
                        {
                            OrderID = 7,
                            EmployeeID = 5,
                            OrderDate = new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4355),
                            ReservationID = 5,
                            TotalAmount = 8.99m
                        },
                        new
                        {
                            OrderID = 8,
                            EmployeeID = 5,
                            OrderDate = new DateTime(2023, 10, 27, 8, 25, 55, 926, DateTimeKind.Local).AddTicks(4357),
                            ReservationID = 5,
                            TotalAmount = 8.99m
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("MenuItemID")
                        .HasColumnType("int");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("MenuItemID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            OrderItemId = 1,
                            MenuItemID = 1,
                            OrderID = 1,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 2,
                            MenuItemID = 3,
                            OrderID = 1,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 3,
                            MenuItemID = 5,
                            OrderID = 2,
                            Quantity = 3
                        },
                        new
                        {
                            OrderItemId = 4,
                            MenuItemID = 1,
                            OrderID = 2,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 5,
                            MenuItemID = 2,
                            OrderID = 3,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 6,
                            MenuItemID = 4,
                            OrderID = 3,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 7,
                            MenuItemID = 2,
                            OrderID = 4,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 8,
                            MenuItemID = 1,
                            OrderID = 5,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 9,
                            MenuItemID = 2,
                            OrderID = 6,
                            Quantity = 2
                        },
                        new
                        {
                            OrderItemId = 10,
                            MenuItemID = 5,
                            OrderID = 7,
                            Quantity = 1
                        },
                        new
                        {
                            OrderItemId = 11,
                            MenuItemID = 5,
                            OrderID = 8,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<int>("TableID")
                        .HasColumnType("int");

                    b.HasKey("ReservationID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantID");

                    b.HasIndex("TableID");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationID = 1,
                            CustomerId = 1,
                            PartySize = 4,
                            ReservationDate = new DateTime(2023, 10, 27, 9, 25, 55, 926, DateTimeKind.Local).AddTicks(4395),
                            RestaurantID = 1,
                            TableID = 1
                        },
                        new
                        {
                            ReservationID = 2,
                            CustomerId = 2,
                            PartySize = 2,
                            ReservationDate = new DateTime(2023, 10, 27, 9, 25, 55, 926, DateTimeKind.Local).AddTicks(4398),
                            RestaurantID = 2,
                            TableID = 2
                        },
                        new
                        {
                            ReservationID = 3,
                            CustomerId = 3,
                            PartySize = 6,
                            ReservationDate = new DateTime(2023, 10, 27, 11, 25, 55, 926, DateTimeKind.Local).AddTicks(4400),
                            RestaurantID = 1,
                            TableID = 3
                        },
                        new
                        {
                            ReservationID = 4,
                            CustomerId = 1,
                            PartySize = 1,
                            ReservationDate = new DateTime(2023, 10, 27, 12, 25, 55, 926, DateTimeKind.Local).AddTicks(4402),
                            RestaurantID = 2,
                            TableID = 2
                        },
                        new
                        {
                            ReservationID = 5,
                            CustomerId = 2,
                            PartySize = 4,
                            ReservationDate = new DateTime(2023, 10, 27, 10, 25, 55, 926, DateTimeKind.Local).AddTicks(4404),
                            RestaurantID = 1,
                            TableID = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.ReservationDetails", b =>
                {
                    b.Property<string>("CustomerFirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerLastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationID")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable((string)null);

                    b.ToView("ReservationDetails", (string)null);
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RestaurantId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpenningHours")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1,
                            Address = "123 Main St.",
                            Name = "Mr Italian",
                            OpenningHours = "9:00 AM - 10:00 PM",
                            PhoneNumber = "555-123-4567"
                        },
                        new
                        {
                            RestaurantId = 2,
                            Address = "456 Manara St.",
                            Name = "Meat Haven",
                            OpenningHours = "10:00 AM - 9:00 PM",
                            PhoneNumber = "555-987-6543"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Table", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantID")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantID");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            TableId = 1,
                            Capacity = 4,
                            RestaurantID = 1
                        },
                        new
                        {
                            TableId = 2,
                            Capacity = 2,
                            RestaurantID = 2
                        },
                        new
                        {
                            TableId = 3,
                            Capacity = 6,
                            RestaurantID = 1
                        },
                        new
                        {
                            TableId = 4,
                            Capacity = 4,
                            RestaurantID = 2
                        },
                        new
                        {
                            TableId = 5,
                            Capacity = 5,
                            RestaurantID = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.Domain.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.Domain.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Order", b =>
                {
                    b.HasOne("RestaurantReservation.Domain.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Domain.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.Domain.MenuItem", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuItemID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Domain.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Domain.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Domain.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("RestaurantReservation.Domain.Table", "Table")
                        .WithMany()
                        .HasForeignKey("TableID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Table", b =>
                {
                    b.HasOne("RestaurantReservation.Domain.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Domain.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}
