using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.EditRestaurant;

/// <summary>
/// ValidatorEditRestaurant
/// </summary>
public class EditRestaurantCommandValidator : AbstractValidator<EditRestaurantCommand>
{
    public EditRestaurantCommandValidator()
    {
        RuleFor(d => d.Name)
            .Length(3, 100);
        
    }
}