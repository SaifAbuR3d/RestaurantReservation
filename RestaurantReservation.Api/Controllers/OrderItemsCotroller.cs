using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Contracts.Models;
using RestaurantReservation.Api.Contracts.RepositoryInterface;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Controllers;

[Route("api/reservations/{reservationId}/orders/{orderId}/orderitems")]
[ApiController]
public class OrderItemsController : ControllerBase
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;
    private readonly IReservationRepository _reservationRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IRestaurantRepository _restaurantRepository;

    public OrderItemsController(IOrderItemRepository orderItemRepository,
        IReservationRepository reservationRepository,
        IOrderRepository orderRepository, 
        IRestaurantRepository restaurantRepository, 
        IMapper mapper)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
        _reservationRepository = reservationRepository;
        _orderRepository = orderRepository;
        _restaurantRepository = restaurantRepository;
    }

    // GET: api/reservations/{reservationId}/orders/{orderId}/orderitems
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetOrderItemsForOrder(int reservationId, int orderId)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        var orderExists = await _orderRepository.OrderExistsAsync(reservationId, orderId);

        if (!reservationExists || !orderExists)
        {
            return BadRequest("Invalid reservation or order Id");
        }

        var orderItems = await _orderItemRepository.GetOrderItemsForOrderAsync(reservationId, orderId);
        return Ok(_mapper.Map<IEnumerable<OrderItemDto>>(orderItems));
    }

    // GET: api/reservations/{reservationId}/orders/{orderId}/orderitems/{orderItemId}
    [HttpGet("{orderItemId}", Name = "GetOrderItem")]
    public async Task<ActionResult<OrderItemDto>> GetOrderItem(int reservationId, int orderId, int orderItemId)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        var orderExists = await _orderRepository.OrderExistsAsync(reservationId, orderId);

        if (!reservationExists || !orderExists)
        {
            return BadRequest("Invalid reservation or order Id");
        }

        var orderItem = await _orderItemRepository.GetOrderItemAsync(reservationId, orderId, orderItemId);
        if (orderItem == null)
        {
            return NotFound("OrderItem not found.");
        }

        return Ok(_mapper.Map<OrderItemDto>(orderItem));
    }

    // POST: api/reservations/{reservationId}/orders/{orderId}/orderitems
    [HttpPost]
    public async Task<ActionResult<OrderItemDto>> PostOrderItem(int reservationId, int orderId, OrderItemForCreationOrUpdateDto orderItemForCreation)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        var orderExists = await _orderRepository.OrderExistsAsync(reservationId, orderId);

        if (!reservationExists || !orderExists)
        {
            return BadRequest("Invalid reservation or order Id");
        }

        var restaurantForReservation = _restaurantRepository.GetRestaurantIdByReservationIdAsync(reservationId);
        var restaurantForMenuItem = _restaurantRepository.GetRestaurantIdByMenuItemIdAsync(orderItemForCreation.MenuItemId);

        if (restaurantForReservation == null ||
            restaurantForMenuItem == null ||
            restaurantForMenuItem != restaurantForReservation)
        {
            return BadRequest("Menu Item not found");
        }

        var orderItemEntity = _mapper.Map<OrderItem>(orderItemForCreation);
        _orderItemRepository.AddOrderItemToOrder(orderId, orderItemEntity);

        await _orderItemRepository.SaveChangesAsync(orderId);

        return CreatedAtRoute("GetOrderItem",
            new { reservationId, orderId, orderItemId = orderItemEntity.OrderItemId },
            _mapper.Map<OrderItemDto>(orderItemEntity));
    }

    // PUT: api/reservations/{reservationId}/orders/{orderId}/orderitems/{orderItemId}
    [HttpPut("{orderItemId}")]
    public async Task<ActionResult> PutOrderItem(int reservationId, int orderId, int orderItemId, OrderItemForCreationOrUpdateDto orderItemForUpdate)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        var orderExists = await _orderRepository.OrderExistsAsync(reservationId, orderId);

        if (!reservationExists || !orderExists)
        {
            return BadRequest("Invalid reservation or order Id");
        }

        var orderItemEntity = await _orderItemRepository.GetOrderItemAsync(reservationId, orderId, orderItemId);
        if (orderItemEntity == null)
        {
            return NotFound("OrderItem not found.");
        }

        var restaurantForReservation = _restaurantRepository.GetRestaurantIdByReservationIdAsync(reservationId);
        var restaurantForMenuItem = _restaurantRepository.GetRestaurantIdByMenuItemIdAsync(orderItemForUpdate.MenuItemId);

        if (restaurantForReservation == null ||
            restaurantForMenuItem == null ||
            restaurantForMenuItem != restaurantForReservation)
        {
            return BadRequest("Menu Item not found");
        }

        _mapper.Map(orderItemForUpdate, orderItemEntity);

        await _orderItemRepository.SaveChangesAsync(orderId);

        return NoContent();
    }

    // PATCH: api/reservations/{reservationId}/orders/{orderId}/orderitems/{orderItemId}
    [HttpPatch("{orderItemId}")]
    public async Task<ActionResult> PatchOrderItem(int reservationId, int orderId,
        int orderItemId, JsonPatchDocument<OrderItemForCreationOrUpdateDto> patchDocument)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        var orderExists = await _orderRepository.OrderExistsAsync(reservationId, orderId);

        if (!reservationExists || !orderExists)
        {
            return BadRequest("Invalid reservation or order Id");
        }

        var orderItemEntity = await _orderItemRepository.GetOrderItemAsync(reservationId, orderId, orderItemId);
        if (orderItemEntity == null)
        {
            return NotFound("OrderItem not found.");
        }

        var orderItemToPatch = _mapper.Map<OrderItemForCreationOrUpdateDto>(orderItemEntity);
        patchDocument.ApplyTo(orderItemToPatch, ModelState);

        if (!ModelState.IsValid || !TryValidateModel(orderItemToPatch))
        {
            return BadRequest(ModelState);
        }

        var restaurantForReservation = _restaurantRepository.GetRestaurantIdByReservationIdAsync(reservationId);
        var restaurantForMenuItem = _restaurantRepository.GetRestaurantIdByMenuItemIdAsync(orderItemToPatch.MenuItemId);

        if (restaurantForReservation == null ||
            restaurantForMenuItem == null ||
            restaurantForMenuItem != restaurantForReservation)
        {
            return BadRequest("Menu Item not found");
        }

        _mapper.Map(orderItemToPatch, orderItemEntity);

        await _orderItemRepository.SaveChangesAsync(orderId);

        return NoContent();
    }

    // DELETE: api/reservations/{reservationId}/orders/{orderId}/orderitems/{orderItemId}
    [HttpDelete("{orderItemId}")]
    public async Task<IActionResult> DeleteOrderItem(int reservationId, int orderId, int orderItemId)
    {
        var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
        var orderExists = await _orderRepository.OrderExistsAsync(reservationId, orderId);

        if (!reservationExists || !orderExists)
        {
            return BadRequest("Invalid reservation or order Id");
        }

        var orderItemEntity = await _orderItemRepository.GetOrderItemAsync(reservationId, orderId, orderItemId);
        if (orderItemEntity == null)
        {
            return NotFound("OrderItem not found");
        }

        _orderItemRepository.DeleteOrderItem(orderItemEntity);
        await _orderItemRepository.SaveChangesAsync(orderId);

        return NoContent();
    }
}
