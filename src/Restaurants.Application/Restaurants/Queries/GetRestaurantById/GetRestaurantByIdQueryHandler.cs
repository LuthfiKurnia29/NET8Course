using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetRestaurantById;

/// <summary>
/// HandlerClassGetRestaurantById
/// </summary>
/// <param name="logger"></param>
/// <param name="restaurantsRepository"></param>
/// <param name="mapper"></param>
public class GetRestaurantByIdQueryHandler(ILogger<GetRestaurantByIdQueryHandler> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    /// <summary>
    /// HandleMethod
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting Restaurant {RestaurantId}", request.Id);
        Console.WriteLine("TESGET");
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id)
            ?? throw new NotFoundException("Tes", request.Id.ToString());
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto;
    }
}