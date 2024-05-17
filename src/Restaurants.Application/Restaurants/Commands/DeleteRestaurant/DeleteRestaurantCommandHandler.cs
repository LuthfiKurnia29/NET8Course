using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

/// <summary>
/// HandlerDeleteRestaurant
/// </summary>
/// <param name="logger"></param>
/// <param name="restaurantsRepository"></param>
public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository) : IRequestHandler<DeleteRestaurantCommand>
{
    /// <summary>
    ///HandleDeleteRestaurantCommand
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting restaurant with id: {request.Id}");
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
        }

        await restaurantsRepository.Delete(restaurant);
    }
}