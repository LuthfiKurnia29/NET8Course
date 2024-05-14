using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants;

/// <summary>
/// InterfaceForRestaurantService
/// </summary>
public interface IRestaurantsService
{
    /// <summary>
    /// GetAllRestaurantsService
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<RestaurantDto>> GetAllRestaurants();

    /// <summary>
    /// GetRestaurantByIdService
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<RestaurantDto?> GetRestaurantsById(Guid id);

    /// <summary>
    /// CreateRestaurant
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task<Guid> Create(CreateRestaurantDto dto);
}