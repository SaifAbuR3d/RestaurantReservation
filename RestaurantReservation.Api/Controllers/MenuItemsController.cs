using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Controllers
{
    [Route("api/restaurants/{restaurantId}/menuitems")]
    [ApiController]
    public class MenuItemsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMenuItemRepository _menuItemRepository;
        private readonly IMapper _mapper;

        public MenuItemsController(IRestaurantRepository restaurantRepository, IMenuItemRepository menuItemRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _menuItemRepository = menuItemRepository;
            _mapper = mapper;
        }


        // GET: api/restaurants/{restaurantId}/menuitems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItems(int restaurantId)
        {
            var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
            if (!restaurantExists)
            {
                return NotFound("Restaurant not found");
            }

            var menuItems = await _menuItemRepository.GetMenuItemsInRestaurantAsync(restaurantId);
            return Ok(_mapper.Map<IEnumerable<MenuItemDto>>(menuItems));
        }


        // GET: api/restaurants/{restaurantId}/menuitems/{menuItemId}
        [HttpGet("{menuItemId}", Name = "GetMenuItem")]
        public async Task<IActionResult> GetMenuItem(int restaurantId, int menuItemId)
        {
            var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
            if (!restaurantExists)
            {
                return NotFound("Restaurant not found");
            }

            var menuItem = await _menuItemRepository.GetMenuItemAsync(restaurantId, menuItemId);
            if (menuItem == null)
            {
                return NotFound("Menu item not found");
            }

            return Ok(_mapper.Map<MenuItemDto>(menuItem));
        }


        // POST: api/restaurants/{restaurantId}/menuitems
        [HttpPost]
        public async Task<IActionResult> PostMenuItem(int restaurantId, MenuItemForCreationDto menuItemForCreation)
        {
            var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
            if (!restaurantExists)
            {
                return NotFound("Restaurant not found");
            }

            var menuItemEntity = _mapper.Map<MenuItem>(menuItemForCreation);
            var createdMenuItem = _menuItemRepository.CreateMenuItem(restaurantId, menuItemEntity);

            await _menuItemRepository.SaveChangesAsync();
            
            return CreatedAtRoute("GetMenuItem",
                new { restaurantId, menuItemId = createdMenuItem.MenuItemId },
                _mapper.Map<MenuItemDto>(createdMenuItem));
        }


        // PUT: api/restaurants/{restaurantId}/menuitems/{menuItemId}
        [HttpPut("{menuItemId}")]
        public async Task<ActionResult> PutMenuItem(int restaurantId, int menuItemId, MenuItemForUpdateDto menuItemForUpdate)
        {
            var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
            if (!restaurantExists)
            {
                return NotFound("Restaurant not found");
            }

            var menuItemEntity = await _menuItemRepository.GetMenuItemAsync(restaurantId, menuItemId);
            if (menuItemEntity == null)
            {
                return NotFound("Menu item not found");
            }

            var targetRestaurantExists = await _restaurantRepository.RestaurantExistsAsync(menuItemForUpdate.RestaurantId); 
            if (!targetRestaurantExists)
            {
                return BadRequest("Target restaurant not found"); 
            }

            _mapper.Map(menuItemForUpdate, menuItemEntity);

            await _menuItemRepository.SaveChangesAsync();

            return NoContent();
        }


        // PATCH: api/restaurants/{restaurantId}/menuitems/{menuItemId}
        [HttpPatch("{menuItemId}")]
        public async Task<ActionResult> PatchMenuItem(int restaurantId, int menuItemId,
            JsonPatchDocument<MenuItemForUpdateDto> patchDocument)
        {
            var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
            if (!restaurantExists)
            {
                return NotFound("Restaurant not found");
            }

            var menuItemEntity = await _menuItemRepository.GetMenuItemAsync(restaurantId, menuItemId);
            if (menuItemEntity == null)
            {
                return NotFound("Menu item not found");
            }

            var menuItemToPatch = _mapper.Map<MenuItemForUpdateDto>(menuItemEntity);
            patchDocument.ApplyTo(menuItemToPatch, ModelState);

            var targetRestaurantExists = await _restaurantRepository.RestaurantExistsAsync(menuItemToPatch.RestaurantId);
            if (!targetRestaurantExists)
            {
                return BadRequest("Target restaurant not found");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(menuItemToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(menuItemToPatch, menuItemEntity);

            await _menuItemRepository.SaveChangesAsync();

            return NoContent();
        }


        // DELETE: api/restaurants/{restaurantId}/menuitems/{menuItemId}
        [HttpDelete("{menuItemId}")]
        public async Task<IActionResult> DeleteMenuItem(int restaurantId, int menuItemId)
        {
            var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
            if (!restaurantExists)
            {
                return NotFound("Restaurant not found");
            }

            var menuItemEntity = await _menuItemRepository.GetMenuItemAsync(restaurantId, menuItemId);
            if (menuItemEntity == null)
            {
                return NotFound("Menu item not found");
            }

            try
            {
                _menuItemRepository.DeleteMenuItem(menuItemEntity);
                await _menuItemRepository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Cannot delete menu item");
            }
            return NoContent();
        }
    }
}
