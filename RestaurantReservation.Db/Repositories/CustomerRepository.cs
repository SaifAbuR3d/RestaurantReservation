﻿using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Domain.Models;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public Customer CreateCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return customer;
    }

    public Customer UpdateCustomer(Customer customer)
    {
        _context.Customers.Update(customer);
        _context.SaveChanges();
        return customer;
    }

    public void DeleteCustomer(int customerId)
    {
        var customer = _context.Customers.Find(customerId);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }

    public void AddReservation(int customerId, Reservation reservation)
    {
        var customer = _context.Customers.Find(customerId);
        if (customer != null)
        {
            customer.Reservations.Add(reservation);
            _context.SaveChanges();
        }
    }

    public List<Customer> FindCustomersWithPartySizeGreaterThan(int partySize)
    {
        return _context.Customers
            .FromSqlRaw("EXEC FindCustomersWithPartySizeGreaterThan {0}", partySize).ToList();
    }
}
