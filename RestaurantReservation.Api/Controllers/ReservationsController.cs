using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Controllers;

[Route("api/reservations")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly ITableRepository _tableRepository;
    private readonly IMapper _mapper;

    public ReservationsController(
        IReservationRepository reservationRepository,
        ICustomerRepository customerRepository,
        IRestaurantRepository restaurantRepository,
        ITableRepository tableRepository,
        IMapper mapper)
    {
        _reservationRepository = reservationRepository;
        _customerRepository = customerRepository;
        _restaurantRepository = restaurantRepository;
        _tableRepository = tableRepository;
        _mapper = mapper;
    }

    // GET: api/reservations
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReservationDto>>> GetReservations()
    {
        var reservations = await _reservationRepository.GetAllReservationsAsync();
        return Ok(_mapper.Map<IEnumerable<ReservationDto>>(reservations));
    }

    // GET: api/reservations/{reservationId}
    [HttpGet("{reservationId}", Name = "GetReservation")]
    public async Task<IActionResult> GetReservation(int reservationId, bool includeOrders = false)
    {
        var reservation = await _reservationRepository.GetReservationAsync(reservationId, includeOrders);
        if (reservation == null)
        {
            return NotFound("Reservation not found");
        }
        if (includeOrders)
        {
            return Ok(_mapper.Map<ReservationWithOrdersDto>(reservation));
        }
        return Ok(_mapper.Map<ReservationDto>(reservation));
    }

    // POST: api/reservations
    [HttpPost]
    public async Task<IActionResult> PostReservation(ReservationForCreationOrUpdateDto reservationForCreation)
    {

        var customerExists = await _customerRepository.CustomerExistsAsync(reservationForCreation.CustomerId);
        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(reservationForCreation.RestaurantId);
        var tableExists = await _tableRepository.TableExistsAsync(reservationForCreation.TableId);

        if (!customerExists || !restaurantExists || !tableExists)
        {
            return BadRequest("Invalid customer, restaurant, or table Id");
        }

        var reservationEntity = _mapper.Map<Reservation>(reservationForCreation);

        _reservationRepository.CreateReservation(reservationEntity);

        await _reservationRepository.SaveChangesAsync();

        return CreatedAtRoute("GetReservation",
            new { reservationId = reservationEntity.ReservationId },
            _mapper.Map<ReservationDto>(reservationEntity));
    }

    // PUT: api/reservations/{reservationId}
    [HttpPut("{reservationId}")]
    public async Task<ActionResult> PutReservation(int reservationId, ReservationForCreationOrUpdateDto reservationForUpdate)
    {
        var reservationEntity = await _reservationRepository.GetReservationAsync(reservationId);
        if (reservationEntity == null)
        {
            return NotFound("Reservation not found");
        }

        var customerExists = await _customerRepository.CustomerExistsAsync(reservationForUpdate.CustomerId);
        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(reservationForUpdate.RestaurantId);
        var tableExists = await _tableRepository.TableExistsAsync(reservationForUpdate.TableId);

        if (!customerExists || !restaurantExists || !tableExists)
        {
            return BadRequest("Invalid customer, restaurant, or table Id");
        }

        _mapper.Map(reservationForUpdate, reservationEntity);

        await _reservationRepository.SaveChangesAsync();

        return NoContent();
    }

    // PATCH: api/reservations/{reservationId}
    [HttpPatch("{reservationId}")]
    public async Task<ActionResult> PatchReservation(int reservationId,
        JsonPatchDocument<ReservationForCreationOrUpdateDto> patchDocument)
    {
        var reservationEntity = await _reservationRepository.GetReservationAsync(reservationId);
        if (reservationEntity == null)
        {
            return NotFound("Reservation not found");
        }

        var reservationToPatch = _mapper.Map<ReservationForCreationOrUpdateDto>(reservationEntity);

        patchDocument.ApplyTo(reservationToPatch, ModelState);

        var customerExists = await _customerRepository.CustomerExistsAsync(reservationToPatch.CustomerId);
        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(reservationToPatch.RestaurantId);
        var tableExists = await _tableRepository.TableExistsAsync(reservationToPatch.TableId);

        if (!customerExists || !restaurantExists || !tableExists)
        {
            return BadRequest("Invalid customer, restaurant, or table Id");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!TryValidateModel(reservationToPatch))
        {
            return BadRequest(ModelState);
        }

        _mapper.Map(reservationToPatch, reservationEntity);

        await _reservationRepository.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/reservations/{reservationId}
    [HttpDelete("{reservationId}")]
    public async Task<IActionResult> DeleteReservation(int reservationId)
    {
        var reservationEntity = await _reservationRepository.GetReservationAsync(reservationId);
        if (reservationEntity == null)
        {
            return NotFound("Reservation not found");
        }

        try
        {
            _reservationRepository.DeleteReservation(reservationEntity);
            await _reservationRepository.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest("Cannot delete reservation, Some orders are attached to it"); 
        }
        return NoContent();
    }
}
