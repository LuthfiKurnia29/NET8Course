using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.EditRestaurant;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers;

/// <summary>
/// 
/// </summary>
/// <param name="mediator"></param>
[ApiController]
[Route("api/restaurants")]
public class RestaurantController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// GetAllRestaurants
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RestaurantDto>>> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    /// <summary>
    /// GetRestaurantById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RestaurantDto>> GetRestaurantById([FromRoute]Guid id)
    {
        var restaurants = await mediator.Send(new GetRestaurantByIdQuery(id));
        return Ok(restaurants);
    }
    
    /// <summary>
    /// DeleteRestaurant
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteRestaurant([FromRoute]Guid id)
    {
        await mediator.Send(new DeleteRestaurantCommand(id));
        return NoContent();
    }


    /// <summary>
    /// CreateRestaurant
    /// </summary>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> CreateRestaurant(CreateRestaurantCommand command)
    {
        var id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetRestaurantById), new { id }, null);
    }

    /// <summary>
    /// EditDataRestaurant
    /// </summary>
    /// <param name="id"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] Guid id, EditRestaurantCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
        return NoContent();
    }
    
}