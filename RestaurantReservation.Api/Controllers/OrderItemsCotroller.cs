using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantReservation.Api.Controllers
{
    [Route("api/reservations/{reservationId}/orders/{orderId}/orderitems")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;
        private readonly IReservationRepository _reservationRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderItemsController(IOrderItemRepository orderItemRepository, IMapper mapper,
            IReservationRepository reservationRepository, IOrderRepository orderRepository)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
            _reservationRepository = reservationRepository;
            _orderRepository = orderRepository;
        }

        // GET: api/reservations/{reservationId}/orders/{orderId}/orderitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItemDto>>> GetOrderItemsForOrder(int reservationId, int orderId)
        {
            var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
            var orderExists = await _orderRepository.OrderExistsAsync(reservationId,orderId);

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
                return NotFound();
            }

            return Ok(_mapper.Map<OrderItemDto>(orderItem));
        }

        // POST: api/reservations/{reservationId}/orders/{orderId}/orderitems
        [HttpPost]
        public async Task<ActionResult<OrderItemDto>> PostOrderItem(int reservationId, int orderId, OrderItemForCreationOrUpdate orderItemForCreation)
        {
            var reservationExists = await _reservationRepository.ReservationExistsAsync(reservationId);
            var orderExists = await _orderRepository.OrderExistsAsync(reservationId, orderId);

            if (!reservationExists || !orderExists)
            {
                return BadRequest("Invalid reservation or order Id");
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
        public async Task<ActionResult> PutOrderItem(int reservationId, int orderId, int orderItemId, OrderItemForCreationOrUpdate orderItemForUpdate)
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
                return NotFound();
            }

            _mapper.Map(orderItemForUpdate, orderItemEntity);

            await _orderItemRepository.SaveChangesAsync(orderId);

            return NoContent();
        }

        // PATCH: api/reservations/{reservationId}/orders/{orderId}/orderitems/{orderItemId}
        [HttpPatch("{orderItemId}")]
        public async Task<ActionResult> PatchOrderItem(int reservationId, int orderId,
            int orderItemId, JsonPatchDocument<OrderItemForCreationOrUpdate> patchDocument)
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
                return NotFound();
            }

            var orderItemToPatch = _mapper.Map<OrderItemForCreationOrUpdate>(orderItemEntity);
            patchDocument.ApplyTo(orderItemToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(orderItemToPatch))
            {
                return BadRequest(ModelState);
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
                return NotFound();
            }

            _orderItemRepository.DeleteOrderItem(orderItemEntity);
            await _orderItemRepository.SaveChangesAsync(orderId);

            return NoContent();
        }
    }
}
