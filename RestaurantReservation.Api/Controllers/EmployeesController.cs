﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Contracts.Models;
using RestaurantReservation.Api.Contracts.RepositoryInterface;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Controllers;

[Route("api/employees")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeesController(IRestaurantRepository restaurantRepository, IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _restaurantRepository = restaurantRepository;
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }


    // GET: api/employees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
    {
        var employees = await _employeeRepository.GetAllEmployeesAsync();
        return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
    }

    // GET: api/employees/{employeeId}
    [HttpGet("{employeeId}", Name = "GetEmployee")]
    public async Task<IActionResult> GetEmployee(int employeeId, bool includeOrders = false)
    {
        var employee =  await _employeeRepository.GetEmployeeAsync(employeeId);
        if (employee == null)
        {
            return NotFound("Employee not found");
        }

        return Ok(includeOrders ? _mapper.Map<EmployeeWithOrdersDto>(employee) : _mapper.Map<EmployeeDto>(employee));
    }

    // GET: api/employees
    [HttpGet("managers")]
    public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetManagers()
    {
        var employees = await _employeeRepository.GetManagers();
        return Ok(_mapper.Map<IEnumerable<EmployeeDto>>(employees));
    }


    [HttpGet("{employeeId}/average-order-amount")]
    public async Task<ActionResult<decimal?>> GetAverageOrderAmountForEmployee(int employeeId)
    {
        var averageOrderAmount = await _employeeRepository.GetAverageOrderAmountAsync(employeeId);

        if (averageOrderAmount == null)
        {
            return NotFound("Employee not found.");
        }

        return Ok(new { AverageOrderAmount = averageOrderAmount });
    }


    // POST: api/employees
    [HttpPost]
    public async Task<IActionResult> PostEmployee(EmployeeForCreationOrUpdate employeeForCreation)
    {
        var employeeEntity = _mapper.Map<Employee>(employeeForCreation);
        _employeeRepository.CreateEmployee(employeeEntity);

        await _employeeRepository.SaveChangesAsync();

        return CreatedAtRoute("GetEmployee",
            new { employeeId = employeeEntity.EmployeeId },
            _mapper.Map<EmployeeDto>(employeeEntity));
    }

    // PUT: api/employees/{employeeId}
    [HttpPut("{employeeId}")]
    public async Task<ActionResult> PutEmployee(int employeeId, EmployeeForCreationOrUpdate employeeForUpdate)
    {
        var employeeEntity = await _employeeRepository.GetEmployeeAsync(employeeId);
        if (employeeEntity == null)
        {
            return NotFound("Employee not found");
        }

        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(employeeForUpdate.RestaurantId);
        if (restaurantExists)
        {
            return NotFound("Restaurant not found");
        }

        _mapper.Map(employeeForUpdate, employeeEntity);

        await _employeeRepository.SaveChangesAsync();

        return NoContent();
    }

    // PATCH: api/employees/{employeeId}
    [HttpPatch("{employeeId}")]
    public async Task<ActionResult> PatchEmployee(int employeeId, JsonPatchDocument<EmployeeForCreationOrUpdate> patchDocument)
    {
        var employeeEntity = await _employeeRepository.GetEmployeeAsync(employeeId);
        if (employeeEntity == null)
        {
            return NotFound("Employee not found");
        }

        var employeeToPatch = _mapper.Map<EmployeeForCreationOrUpdate>(employeeEntity);

        patchDocument.ApplyTo(employeeToPatch, ModelState);

        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(employeeToPatch.RestaurantId);
        if (restaurantExists)
        {
            return NotFound("Restaurant not found");
        }

        if (!ModelState.IsValid || !TryValidateModel(employeeToPatch))
        {
            return BadRequest(ModelState);
        }

        _mapper.Map(employeeToPatch, employeeEntity);

        await _employeeRepository.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/employees/{employeeId}
    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> DeleteEmployee(int employeeId)
    {
        var employeeEntity = await _employeeRepository.GetEmployeeAsync(employeeId);
        if (employeeEntity == null)
        {
            return NotFound("Employee not found");
        }

        try
        {
            _employeeRepository.DeleteEmployee(employeeEntity);
            await _employeeRepository.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest("Cannot delete the employee, some orders are attached to him");
        }

        return NoContent();
    }
}
