using MediatR;

namespace Restaurants.Application.Restaurants.Commands.EditRestaurant;

/// <summary>
/// EditRestaurantCommand
/// </summary>
/// <param name="id"></param>
public class EditRestaurantCommand(Guid id) : IRequest<bool>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool HasDelivery { get; set; }
}