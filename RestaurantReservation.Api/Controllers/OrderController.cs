using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Controllers;

[Route("api/reservations/{reservationId}/orders")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IMapper _mapper;

    public OrdersController(IOrderRepository orderRepository,
        IRestaurantRepository restaurantRepository,
        IReservationRepository reservationRepository,
        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _restaurantRepository = restaurantRepository;
        _reservationRepository = reservationRepository;
        _mapper = mapper;
    }

    // GET: api/reservations/{reservationId}/orders
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrdersForReservation(int reservationId)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        if (!reservationExists)
        {
            return NotFound("Reservation not found.");
        }

        var orders = await _orderRepository.GetOrdersForReservationAsync(reservationId);
        return Ok(_mapper.Map<IEnumerable<OrderDto>>(orders));
    }

    // GET: api/reservations/{reservationId}/orders/{orderId}
    [HttpGet("{orderId}", Name = "GetOrder")]
    public async Task<ActionResult<OrderDto>> GetOrder(int reservationId, int orderId)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        if (!reservationExists)
        {
            return NotFound("Reservation not found.");
        }

        var order = await _orderRepository.GetOrderAsync(reservationId, orderId);
        if (order == null)
        {
            return NotFound("Order not found.");
        }

        return Ok(_mapper.Map<OrderDto>(order));
    }

    // POST: api/reservations/{reservationId}/orders
    [HttpPost]
    public async Task<ActionResult<OrderDto>> PostOrder(int reservationId, OrderForCreationDto orderForCreation)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        if (!reservationExists)
        {
            return NotFound("Reservation not found.");
        }

        var restaurantForReservation = _restaurantRepository.GetRestaurantIdByReservationIdAsync(reservationId);
        var restaurantForEmployee = _restaurantRepository.GetRestaurantIdByEmployeeIdAsync(orderForCreation.EmployeeId); 

        if (restaurantForEmployee != restaurantForReservation)
        {
            return BadRequest("Employee not found.");
        }

        var orderEntity = _mapper.Map<Order>(orderForCreation);
        _orderRepository.CreateOrder(reservationId, orderEntity);

        await _orderRepository.SaveChangesAsync();

        return CreatedAtRoute("GetOrder",
            new { reservationId, orderId = orderEntity.OrderId },
            _mapper.Map<OrderDto>(orderEntity));
    }

    // PUT: api/reservations/{reservationId}/orders/{orderId}
    [HttpPut("{orderId}")]
    public async Task<ActionResult> PutOrder(int reservationId, int orderId, OrderForUpdateDto orderForUpdate)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        if (!reservationExists)
        {
            return NotFound("Reservation not found.");
        }

        var orderEntity = await _orderRepository.GetOrderAsync(reservationId, orderId);
        if (orderEntity == null)
        {
            return NotFound("Order not found.");
        }

        var restaurantForReservation = _restaurantRepository.GetRestaurantIdByReservationIdAsync(orderForUpdate.ReservationId);
        var restaurantForEmployee = _restaurantRepository.GetRestaurantIdByEmployeeIdAsync(orderForUpdate.EmployeeId);

        if (restaurantForEmployee != restaurantForReservation)
        {
            return BadRequest("Employee not found.");
        }

        _mapper.Map(orderForUpdate, orderEntity);

        await _orderRepository.SaveChangesAsync();

        return NoContent();
    }

    // PATCH: api/reservations/{reservationId}/orders/{orderId}
    [HttpPatch("{orderId}")]
    public async Task<ActionResult> PatchOrder(int reservationId, int orderId, JsonPatchDocument<OrderForUpdateDto> patchDocument)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        if (!reservationExists)
        {
            return NotFound("Reservation not found.");
        }

        var orderEntity = await _orderRepository.GetOrderAsync(reservationId, orderId);
        if (orderEntity == null)
        {
            return NotFound("Order not found.");
        }

        var orderToPatch = _mapper.Map<OrderForUpdateDto>(orderEntity);
        patchDocument.ApplyTo(orderToPatch, ModelState);

        if (!ModelState.IsValid || !TryValidateModel(orderToPatch))
        {
            return BadRequest(ModelState);
        }

        var restaurantForReservation = _restaurantRepository.GetRestaurantIdByReservationIdAsync(orderToPatch.ReservationId);
        var restaurantForEmployee = _restaurantRepository.GetRestaurantIdByEmployeeIdAsync(orderToPatch.EmployeeId);

        if (restaurantForEmployee != restaurantForReservation)
        {
            return BadRequest("Employee not found.");
        }

        _mapper.Map(orderToPatch, orderEntity);

        await _orderRepository.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/reservations/{reservationId}/orders/{orderId}
    [HttpDelete("{orderId}")]
    public async Task<IActionResult> DeleteOrder(int reservationId, int orderId)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        if (!reservationExists)
        {
            return NotFound("Reservation not found.");
        }

        var orderEntity = await _orderRepository.GetOrderAsync(reservationId, orderId);
        if (orderEntity == null)
        {
            return NotFound("Order not found.");
        }

        try
        {
            _orderRepository.DeleteOrder(orderEntity);
            await _orderRepository.SaveChangesAsync();
        }
        catch (Exception)
        {
            return BadRequest("Cannot delete the order, some order items are attached to it.");
        }

        return NoContent();
    }
}
