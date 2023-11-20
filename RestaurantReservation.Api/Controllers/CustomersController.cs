using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Controllers;

[Route("api/customers")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CustomersController(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    // GET: api/Customers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerWithoutReservationsDto>>> GetCustomers()
    {
        var customers = await _customerRepository.GetAllCustomersAsync();
        return Ok(_mapper.Map<IEnumerable<CustomerWithoutReservationsDto>>(customers));
    }

    // GET: api/Customers/5
    [HttpGet("{id}", Name = "GetCustomer")]
    public async Task<IActionResult> GetCustomer(int id, bool includeReservations = false)
    {
        var customer = await _customerRepository.GetCustomerAsync(id, includeReservations);
        if (customer == null)
        {
            return NotFound();
        }

        if (includeReservations)
        {
            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        return Ok(_mapper.Map<CustomerWithoutReservationsDto>(customer));
    }

    // POST: api/Customers
    [HttpPost]
    public async Task<IActionResult> PostCustomer(CustomerForCreationDto customer)
    {
        var finalCustomer = _mapper.Map<Customer>(customer);

        _customerRepository.CreateCustomer(finalCustomer);

        await _customerRepository.SaveChangesAsync();

        return CreatedAtRoute("GetCustomer",
            new {id = finalCustomer.CustomerId},
            _mapper.Map<CustomerWithoutReservationsDto>(finalCustomer));
    }

    // PUT: api/Customers/5
    [HttpPut("{id}")]
    public async Task<ActionResult> PutCustomer(int id, CustomerForUpdateDto customer)
    {

        var customerEntity = await _customerRepository.GetCustomerAsync(id);
        if (customerEntity == null)
        {
            return NotFound();
        }

        _mapper.Map(customer, customerEntity);

        // now we have updated entity
        await _customerRepository.SaveChangesAsync();

        return NoContent();
    }

    // PATCH: api/Customers/5
    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchCustomer(int id,
        JsonPatchDocument<CustomerForUpdateDto> patchDocument)
    {
        var customerEntity = await _customerRepository.GetCustomerAsync(id);
        if (customerEntity == null)
        {
            return NotFound();
        }

        var customerToPatch = _mapper.Map<CustomerForUpdateDto>(customerEntity);

        patchDocument.ApplyTo(customerToPatch, ModelState);

        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        _mapper.Map(customerToPatch, customerEntity);

        await _customerRepository.SaveChangesAsync();

        return NoContent();
    }


    // DELETE: api/Customers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(int id)
    {
        var customerEntity = await _customerRepository.GetCustomerAsync(id);
        if (customerEntity == null)
        {
            return NotFound();
        }

        _customerRepository.DeleteCustomer(customerEntity);
        await _customerRepository.SaveChangesAsync();

        return NoContent();
    }

}