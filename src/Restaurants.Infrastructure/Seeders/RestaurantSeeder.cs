using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

/// <summary>
/// Seeder Data Restaurants
/// </summary>
/// <param name="context"></param>
public class RestaurantSeeder(RestaurantsDbContext context) : IRestaurantSeeder
{
    /// <summary>
    /// ImplementationFunctionSeedData
    /// </summary>
    public async Task Seed()
    {
        if (await context.Database.CanConnectAsync())
        {
            if (!context.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                context.Restaurants.AddRange(restaurants);
                await context.SaveChangesAsync();
            }
        }
    }

    /// <summary>
    /// DataDummyRestaurants
    /// </summary>
    /// <returns></returns>
    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants =
        [
            new()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "KFC (Short for Kentucky Fried Chicken) is an American fast food restaurant",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes =
                [
                    new()
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "Nashville Hot Chicken (10 pcs.)",
                        Price = 10.30M
                    },
                    new()
                    {
                        Name = "Chicken Spicy Buckets",
                        Description = "Chicken Spicy (10 pcs.)",
                        Price = 15.50M
                    },
                    new()
                    {
                        Name = "Chicken Nuggets",
                        Description = "Chicken Nuggets Ala Carte (5 pcs.)",
                        Price = 5.30M
                    },
                ],
                Address = new()
                {
                    City = "Singapore",
                    Street = "Marina Bay st 5",
                    PostalCode = "SG MB5"
                }
            },
            new()
            {
                Name = "MCDonald",
                Category = "Fast Food",
                Description = "MCDonald's Corporation (McDonald's),incorporate on December 21, 1964",
                ContactEmail = "contact@mcdonald.com",
                HasDelivery = true,
                Address = new()
                {
                    City = "Malaysia",
                    Street = "Abdul Muiz",
                    PostalCode = "AM5 MSYA"
                }
            }
        ];
        return restaurants;
    }
}