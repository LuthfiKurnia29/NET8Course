using FluentValidation;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Validators;

/// <summary>
/// ValidatorCreateRestaurantDTO
/// </summary>
public class CreateRestaurantDtoValidator : AbstractValidator<CreateRestaurantDto>
{
    private readonly List<string> validCategories = ["Italian", "Mexican", "Japanese", "American", "Indian"];
    public CreateRestaurantDtoValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100);
        RuleFor(dto => dto.Description)
            .NotEmpty().WithMessage("Description is required.");
        RuleFor(dto => dto.Category)
            .Must(category => validCategories.Contains(category))
            .WithMessage("Invalid Category. Please choose from the valid categories.");
            // .Custom((val, ctx) =>
            // {
            //     var isValidCategory = validCategories.Contains(val);
            //     if (!isValidCategory)
            //     {
            //         ctx.AddFailure("Category", "Invalid Category. Please choose from the valid categories.");
            //     }
            // });
        RuleFor(dto => dto.ContactEmail)
            .EmailAddress().WithMessage("Please provide a valid email address.");
        RuleFor(dto => dto.PostalCode)
            .Matches(@"^{2}-\d{3}$")
            .WithMessage("Please provide a valid postal code (XX-XXX).");
    }
}