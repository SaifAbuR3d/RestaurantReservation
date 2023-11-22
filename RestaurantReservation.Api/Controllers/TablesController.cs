using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.Api.Contracts.Models;
using RestaurantReservation.Api.Contracts.RepositoryInterface;
using RestaurantReservation.Domain.Entities;

namespace RestaurantReservation.Api.Controllers;

[Route("api/restaurants/{restaurantId}/tables")]
[ApiController]
public class TablesController : ControllerBase
{
    private readonly IRestaurantRepository _restaurantRepository;
    private readonly ITableRepository _tablesRepository;


    private readonly IMapper _mapper;

    public TablesController(IRestaurantRepository restaurantsRepository,
        ITableRepository tablesRepository, IMapper mapper)
    {
        _restaurantRepository = restaurantsRepository;
        _tablesRepository = tablesRepository;
        _mapper = mapper;
    }


    // GET: api/restaurants/{restaurantId}/tables
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TableDto>>> GetTables(int restaurantId)
    {
        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
        if (!restaurantExists)
        {
            return NotFound("Restaurant not found");
        }

        var tables = await _tablesRepository.GetTablesInRestaurantAsync(restaurantId);
        return Ok(_mapper.Map<IEnumerable<TableDto>>(tables));
    }


    // GET: api/restaurants/{restaurantId}/tables/{tableId}
    [HttpGet("{tableId}", Name = "GetTable")]
    public async Task<ActionResult<TableDto>> GetTable(int restaurantId, int tableId)
    {
        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
        if (!restaurantExists)
        {
            return NotFound("Restaurant not found");
        }

        var table = await _tablesRepository.GetTableAsync(restaurantId, tableId);
        if (table == null)
        {
            return NotFound("Table not found");
        }

        return Ok(_mapper.Map<TableDto>(table));
    }


    // POST: api/restaurants/{restaurantId}/tables
    [HttpPost]
    public async Task<IActionResult> PostTable(int restaurantId, TableForCreationOrUpdateDto tableForCreation)
    {
        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
        if (!restaurantExists)
        {
            return NotFound("Restaurant not found");
        }

        var tableEntity = _mapper.Map<Table>(tableForCreation);
        var createdTable = _tablesRepository.CreateTable(restaurantId, tableEntity);

        await _tablesRepository.SaveChangesAsync();

        return CreatedAtRoute("GetTable",
            new { restaurantId, tableId = createdTable.TableId },
            _mapper.Map<TableDto>(createdTable));
    }

    // PUT: api/restaurants/{restaurantId}/tables/{tableId}
    [HttpPut("{tableId}")]
    public async Task<ActionResult> PutTable(int restaurantId, int tableId, TableForCreationOrUpdateDto tableForUpdate)
    {
        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
        if (!restaurantExists)
        {
            return NotFound("Restaurant not found");
        }

        var tableEntity = await _tablesRepository.GetTableAsync(restaurantId, tableId);
        if (tableEntity == null)
        {
            return NotFound("Table not found");
        }

        _mapper.Map(tableForUpdate, tableEntity);

        await _tablesRepository.SaveChangesAsync();

        return NoContent();
    }


    // PATCH: api/restaurants/{restaurantId}/tables/{tableId}
    [HttpPatch("{tableId}")]
    public async Task<ActionResult> PatchTable(int restaurantId, int tableId,
        JsonPatchDocument<TableForCreationOrUpdateDto> patchDocument)
    {
        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
        if (!restaurantExists)
        {
            return NotFound("Restaurant not found");
        }

        var tableEntity = await _tablesRepository.GetTableAsync(restaurantId, tableId);
        if (tableEntity == null)
        {
            return NotFound("Table not found.");
        }

        var tableToPatch = _mapper.Map<TableForCreationOrUpdateDto>(tableEntity);
        patchDocument.ApplyTo(tableToPatch, ModelState);

        if (!ModelState.IsValid || !TryValidateModel(tableToPatch))
        {
            return BadRequest(ModelState);
        }

        _mapper.Map(tableToPatch, tableEntity);

        await _tablesRepository.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/restaurants/{restaurantId}/tables/{tableId}
    [HttpDelete("{tableId}")]
    public async Task<IActionResult> DeleteTable(int restaurantId, int tableId)
    {
        var restaurantExists = await _restaurantRepository.RestaurantExistsAsync(restaurantId);
        if (!restaurantExists)
        {
            return NotFound("Restaurant not found.");
        }

        var tableEntity = await _tablesRepository.GetTableAsync(restaurantId, tableId);
        if (tableEntity == null)
        {
            return NotFound("Table not found.");
        }
        try
        {
            _tablesRepository.DeleteTable(tableEntity);
            await _tablesRepository.SaveChangesAsync();
        } catch (Exception)
        {
            return BadRequest("Cannot delete the table, some reservations attached to it.");
        }
        return NoContent();
    }

}
