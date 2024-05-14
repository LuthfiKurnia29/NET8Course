namespace Restaurants.Infrastructure.Seeders;

/// <summary>
/// Interface RestaurantSeeder
/// </summary>
public interface IRestaurantSeeder
{
    /// <summary>
    /// FunctionToSeedData
    /// </summary>
    /// <returns></returns>
    Task Seed();
}