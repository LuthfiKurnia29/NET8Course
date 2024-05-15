using MediatR;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

/// <summary>
/// QueryGetALlRestaurants
/// </summary>
public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
        
}