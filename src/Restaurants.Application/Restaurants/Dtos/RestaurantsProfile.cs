using AutoMapper;
using Restaurants.Application.Restaurants.Commands.EditRestaurant;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.Dtos;

/// <summary>
/// DtoLogic
/// </summary>
public class RestaurantsProfile : Profile
{
    /// <summary>
    /// MappingProfile
    /// </summary>
    public RestaurantsProfile()
    {
        
        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(d => d.City, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(d => d.Street, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(src => src.Dishes));

        CreateMap<EditRestaurantCommand, Restaurant>();
    }
}