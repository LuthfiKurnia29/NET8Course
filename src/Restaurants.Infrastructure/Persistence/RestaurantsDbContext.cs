using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;

namespace Restaurants.Infrastructure.Persistence;

/// <summary>
/// DBContext
/// </summary>
/// <param name="options"></param>
public class RestaurantsDbContext(DbContextOptions<RestaurantsDbContext> options) : DbContext(options)
{
    internal DbSet<Restaurant> Restaurants { get; set; }
    internal DbSet<Dish> Dishes { get; set; }

    /// <summary>
    /// RelationTable
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Restaurant>()
            .OwnsOne(r => r.Address);
        modelBuilder.Entity<Restaurant>()
            .HasMany(r => r.Dishes)
            .WithOne()
            .HasForeignKey(d => d.RestaurantId);
    }
}