using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

/// <summary>
/// HandlerClassGetAllRestaurant
/// </summary>
/// <param name="logger"></param>
/// <param name="restaurantsRepository"></param>
/// <param name="mapper"></param>
public class GetAllRestaurantsQueryHandler(ILogger<GetAllRestaurantsQueryHandler> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
{
    /// <summary>
    /// HandleMethod
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting All Restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();

        // Adding Map
        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        
        return restaurantsDto!;
    }
}