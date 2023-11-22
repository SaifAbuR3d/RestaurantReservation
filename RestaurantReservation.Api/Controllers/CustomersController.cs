using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Contracts.Models;
using RestaurantReservation.Api.Contracts.RepositoryInterface;
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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await _customerRepository.GetAllCustomersAsync();
        return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
    }

    [HttpGet("{customerId}", Name = "GetCustomer")]
    public async Task<ActionResult<CustomerDto>> GetCustomer(int customerId, bool includeReservations = false)
    {
        var customer = await _customerRepository.GetCustomerAsync(customerId, includeReservations);
        if (customer == null)
        {
            return NotFound($"Customer not found.");
        }

        return includeReservations
            ? Ok(_mapper.Map<CustomerDto>(customer))
            : Ok(_mapper.Map<CustomerWithoutReservationsDto>(customer));
    }

    [HttpPost]
    public async Task<ActionResult<CustomerDto>> PostCustomer(CustomerForCreationDto customer)
    {
        var customerEntity = _mapper.Map<Customer>(customer);
        _customerRepository.CreateCustomer(customerEntity);
        await _customerRepository.SaveChangesAsync();

        return CreatedAtRoute("GetCustomer",
            new { customerId = customerEntity.CustomerId },
            _mapper.Map<CustomerDto>(customerEntity));
    }

    [HttpPut("{customerId}")]
    public async Task<ActionResult> PutCustomer(int customerId, CustomerForUpdateDto customer)
    {
        var customerEntity = await _customerRepository.GetCustomerAsync(customerId);
        if (customerEntity == null)
        {
            return NotFound($"Customer not found.");
        }

        _mapper.Map(customer, customerEntity);
        await _customerRepository.SaveChangesAsync();

        return NoContent();
    }

    [HttpPatch("{customerId}")]
    public async Task<ActionResult> PatchCustomer(int customerId, JsonPatchDocument<CustomerForUpdateDto> patchDocument)
    {
        var customerEntity = await _customerRepository.GetCustomerAsync(customerId);
        if (customerEntity == null)
        {
            return NotFound($"Customer not found.");
        }

        var customerToPatch = _mapper.Map<CustomerForUpdateDto>(customerEntity);
        patchDocument.ApplyTo(customerToPatch, ModelState);

        if (!ModelState.IsValid || !TryValidateModel(customerToPatch))
        {
            return BadRequest(ModelState);
        }

        _mapper.Map(customerToPatch, customerEntity);
        await _customerRepository.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{customerId}")]
    public async Task<IActionResult> DeleteCustomer(int customerId)
    {
        var customerEntity = await _customerRepository.GetCustomerAsync(customerId);
        if (customerEntity == null)
        {
            return NotFound("Customer not found.");
        }

        try
        {
            _customerRepository.DeleteCustomer(customerEntity);
            await _customerRepository.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest("Cannot delete the customer, some reservations are attached to him");
        }
        return NoContent();
    }
}
