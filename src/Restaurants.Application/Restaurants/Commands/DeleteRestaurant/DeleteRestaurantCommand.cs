using MediatR;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

/// <summary>
/// DeleteRestaurantCommand
/// </summary>
/// <param name="id"></param>
public class DeleteRestaurantCommand(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}