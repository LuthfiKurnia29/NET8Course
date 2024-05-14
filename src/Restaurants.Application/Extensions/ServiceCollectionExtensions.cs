using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurants.Application.Restaurants;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// DependencyInjectionApplication
    /// </summary>
    /// <param name="services"></param>
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddScoped<IRestaurantsService, RestaurantsService>();

        // Adding Automapper
        services.AddAutoMapper(applicationAssembly);
        
        // Adding Fluent Validation
        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();
    }   
}