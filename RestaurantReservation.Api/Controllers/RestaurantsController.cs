using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Models;
using RestaurantReservation.Db.Repositories;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Controllers
{
    [Route("api/restaurants")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantRepository _restaurantRepository;
        private readonly IMapper _mapper;

        public RestaurantsController(IRestaurantRepository restaurantsRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantsRepository;
            _mapper = mapper;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetRestaurant()
        {
            var restaurants = await _restaurantRepository.GetAllRestaurantsAsync();
            return Ok(_mapper.Map<IEnumerable<RestaurantDto>>(restaurants));
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}", Name = "GetRestaurant")]
        public async Task<IActionResult> GetRestaurant(int id, bool includeEmployees = false,
            bool includeMenuItems = false)
        {
            if (includeMenuItems && includeEmployees)
            {
                return BadRequest("Cannot include both employees and menuItems, choose at most one");
            }

            var restaurant = await _restaurantRepository.GetRestaurantAsync(id, includeEmployees, includeMenuItems);

            if (restaurant == null) 
            {
                return NotFound("Restaurant not found.");
            }

            if (includeEmployees)
            {
                return Ok(_mapper.Map<RestaurantWithEmployeesDto>(restaurant));
            }
            else if (includeMenuItems)
            {
                return Ok(_mapper.Map<RestaurantWithMenuItemsDto>(restaurant));
            }

            return Ok(_mapper.Map<RestaurantDto>(restaurant));
        }

        // POST: api/Restaurants
        [HttpPost]
        public async Task<IActionResult> PostRestaurant(RestaurantIsolatedDto restaurant)
        {
            var finalRestaurant = _mapper.Map<Restaurant>(restaurant);

            _restaurantRepository.CreateRestaurant(finalRestaurant);

            await _restaurantRepository.SaveChangesAsync();

            return CreatedAtRoute("GetRestaurant",
                new{ id = finalRestaurant.RestaurantId},
                _mapper.Map<RestaurantDto>(finalRestaurant));
        }

        // PUT: api/Restaurants/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutRestaurant(int id, RestaurantIsolatedDto restaurant)
        {

            var restaurantEntity = await _restaurantRepository.GetRestaurantAsync(id);
            if (restaurantEntity == null)
            {
                return NotFound("Restaurant not found.");
            }

            _mapper.Map(restaurant, restaurantEntity);

            await _restaurantRepository.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/Restaurants/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchRestaurant(int id,
            JsonPatchDocument<RestaurantIsolatedDto> patchDocument)
        {
            var restaurantEntity = await _restaurantRepository.GetRestaurantAsync(id);
            if (restaurantEntity == null)
            {
                return NotFound("Restaurant not found.");
            }

            var restaurantToPatch = _mapper.Map<RestaurantIsolatedDto>(restaurantEntity);

            patchDocument.ApplyTo(restaurantToPatch, ModelState);

            if (!ModelState.IsValid || !TryValidateModel(restaurantToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(restaurantToPatch, restaurantEntity);

            await _restaurantRepository.SaveChangesAsync();

            return NoContent();
        }


        //?
        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurantEntity = await _restaurantRepository.GetRestaurantAsync(id);
            if (restaurantEntity == null)
            {
                return NotFound("Restaurant not found.");
            }

            try
            {
                _restaurantRepository.DeleteRestaurant(restaurantEntity);
                await _restaurantRepository.SaveChangesAsync();
            }
            catch (Exception) 
            {
                return BadRequest("Cannot delete the restaurant.");
            }
            return NoContent();
        }

    }
}
