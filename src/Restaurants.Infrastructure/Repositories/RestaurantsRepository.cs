using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

/// <summary>
/// ClassImplementInterfaceRepositoryInDomain
/// </summary>
/// <param name="context"></param>
internal class RestaurantsRepository(RestaurantsDbContext context) 
    : IRestaurantsRepository
{
    /// <summary>
    /// GetAllRestaurants
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await context.Restaurants.ToListAsync();
        return restaurants;
    }

    /// <summary>
    /// GetByIdRestaurant
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Restaurant> GetRestaurantByIdAsync(Guid id)
    {
        return await context.Restaurants.Include(x => x.Dishes).Where(x => x.Id == id).FirstAsync();
    }

    /// <summary>
    /// CreateRestaurant
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public async Task<Guid> Create(Restaurant entity)
    {
        var restaurants = await context.Restaurants.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity.Id;
    }
}