using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.EditRestaurant;

/// <summary>
/// ValidateEditRestaurant
/// </summary>
public class EditRestaurantCommandValidator : AbstractValidator<EditRestaurantCommand>
{
    public EditRestaurantCommandValidator()
    {
        RuleFor(d => d.Name)
            .Length(3, 100);
        
    }
}