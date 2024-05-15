using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.CreateRestaurant;

/// <summary>
/// HandlerClassCreateRestaurantCommand
/// </summary>
/// <param name="logger"></param>
/// <param name="mapper"></param>
/// <param name="restaurantsRepository"></param>
public class CreateRestaurantCommandHandler(ILogger<CreateRestaurantCommandHandler> logger, IMapper mapper, IRestaurantsRepository restaurantsRepository) : IRequestHandler<CreateRestaurantCommand, Guid>
{
    /// <summary>
    /// HanldeMethod
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Guid> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Create a new Restaurant");
        var restaurant = mapper.Map<Restaurant>(request);
        Guid id = await restaurantsRepository.Create(restaurant);
        return id;
    }
}