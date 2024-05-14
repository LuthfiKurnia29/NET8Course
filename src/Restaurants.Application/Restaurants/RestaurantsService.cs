using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;
/// <summary>
/// ImplementInterfaceRestaurantsInApp
/// </summary>
/// <param name="restaurantsRepository"></param>
/// <param name="logger"></param>
public class RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
{
    /// <summary>
    /// GetAllRestaurants
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting All Restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();

        // Adding Map
        var restaurantsDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantsDto!;
    }

    /// <summary>
    /// GetByIdRestaurant
    /// </summary>
    /// <param name="idRestaurant"></param>
    /// <returns></returns>
    public async Task<RestaurantDto?> GetRestaurantsById(Guid idRestaurant)
    {
        logger.LogInformation($"Getting Restaurant {idRestaurant}");
        var restaurant = await restaurantsRepository.GetRestaurantByIdAsync(idRestaurant);
        var restaurantDto = mapper.Map<RestaurantDto?>(restaurant);
        return restaurantDto;
    }

    /// <summary>
    /// CreateRestaurant
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<Guid> Create(CreateRestaurantDto dto)
    {
        logger.LogInformation("Create a new Restaurant");
        var restaurant = mapper.Map<Restaurant>(dto);
        Guid id = await restaurantsRepository.Create(restaurant);
        return id;
    }
}