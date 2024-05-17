using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.EditRestaurant;

/// <summary>
/// HandleEditRestaurant
/// </summary>
/// <param name="logger"></param>
/// <param name="restaurantsRepository"></param>
/// <param name="mapper"></param>
public class EditRestaurantCommandHandler(ILogger<EditRestaurantCommandHandler> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<EditRestaurantCommand>
{
    public async Task Handle(EditRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating Restaurant with id : {RestaurantId} with {@EditRestaurant}", request.Id, request);
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(request.Id);
        if (restaurant is null)
        {
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
        }

        mapper.Map(request, restaurant);
        
        restaurant.Name = request.Name;
        restaurant.Description = request.Description;
        restaurant.HasDelivery = request.HasDelivery;

        await restaurantsRepository.SaveChanges();
    }
}