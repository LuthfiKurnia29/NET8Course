using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.API.Controllers;

/// <summary>
/// ControllerRestaurant
/// </summary>
/// <param name="restaurantsService"></param>
[ApiController]
[Route("api/restaurants")]
public class RestaurantController(IRestaurantsService restaurantsService) : ControllerBase
{
    /// <summary>
    /// GetAllRestaurants
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }

    /// <summary>
    /// GetRestaurantById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRestaurantById([FromRoute]Guid id)
    {
        var restaurants = await restaurantsService.GetRestaurantsById(id);
        if (restaurants is null)
        {
            return NotFound();
        }
        return Ok(restaurants);
    }

    /// <summary>
    /// CreateNewRestaurant
    /// </summary>
    /// <param name="createRestaurantDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto createRestaurantDto)
    {
        var id = await restaurantsService.Create(createRestaurantDto);
        return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
    }
}