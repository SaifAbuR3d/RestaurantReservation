using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Contracts.Models;
using RestaurantReservation.Api.Contracts;
using RestaurantReservation.Db.Repositories.RepositoryInterface;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Controllers;

[ApiVersion("1.0")]
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

    /// <summary>
    /// Gets all customers.
    /// </summary>
    /// <returns>A list of customer data transfer objects.</returns>
    /// <response code="200">Returns the list of customers.</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
    {
        var customers = await _customerRepository.GetAllCustomersAsync();
        return Ok(_mapper.Map<IEnumerable<CustomerDto>>(customers));
    }

    /// <summary>
    /// Gets a specific customer by ID.
    /// </summary>
    /// <param name="customerId">The ID of the customer to retrieve.</param>
    /// <param name="includeReservations">Flag to include reservations in the response.</param>
    /// <returns>The customer data transfer object.</returns>
    /// <response code="200">Returns the requested customer.</response>
    /// <response code="404">If the customer with the specified ID is not found.</response>
    [HttpGet("{customerId}", Name = "GetCustomer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CustomerDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <param name="customer">The data for the new customer.</param>
    /// <returns>The created customer data transfer object.</returns>
    /// <response code="201">Returns the created customer.</response>
    /// <response code="400">If data is invalid.</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
    public async Task<ActionResult<CustomerDto>> PostCustomer(CustomerForCreationDto customer)
    {
        var customerEntity = _mapper.Map<Customer>(customer);
        _customerRepository.CreateCustomer(customerEntity);
        await _customerRepository.SaveChangesAsync();

        return CreatedAtRoute("GetCustomer",
            new { customerId = customerEntity.CustomerId },
            _mapper.Map<CustomerDto>(customerEntity));
    }

    /// <summary>
    /// Updates an existing customer.
    /// </summary>
    /// <param name="customerId">The ID of the customer to update.</param>
    /// <param name="customer">The updated data for the customer.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">If the update is successful.</response>
    /// <response code="404">If the customer with the specified ID is not found.</response>
    /// <response code="400">if the updated data is invalid</response>

    [HttpPut("{customerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

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

    /// <summary>
    /// Partially updates an existing customer.
    /// </summary>
    /// <param name="customerId">The ID of the customer to update.</param>
    /// <param name="patchDocument">The JSON patch document with partial update operations.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">If the update is successful.</response>
    /// <response code="400">If the patch document or updated data is invalid.</response>
    /// <response code="404">If the customer with the specified ID is not found.</response>
    [HttpPatch("{customerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Deletes an existing customer.
    /// </summary>
    /// <param name="customerId">The ID of the customer to delete.</param>
    /// <returns>No content if successful.</returns>
    /// <response code="204">If the deletion is successful.</response>
    /// <response code="404">If the customer with the specified ID is not found.</response>
    /// <response code="400">If the customer cannot be deleted</response>

    [HttpDelete("{customerId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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