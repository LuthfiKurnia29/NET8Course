using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

/// <summary>
/// InterfaceRepoRestaurants
/// </summary>
public interface IRestaurantsRepository
{
    /// <summary>
    /// GetAllRestaurants
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Restaurant>> GetAllAsync();
    /// <summary>
    /// GetByIdRestaurant
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<Restaurant> GetRestaurantByIdAsync(Guid id);
    /// <summary>
    /// CreateRestaurant
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<Guid> Create(Restaurant entity);

    /// <summary>
    /// DeleteRestaurant
    /// </summary>
    /// <param name="restaurant"></param>
    /// <returns></returns>
    Task Delete(Restaurant restaurant);
    
    /// <summary>
    /// SaveChangesInheritInDBContext
    /// </summary>
    /// <returns></returns>
    Task SaveChanges();
}