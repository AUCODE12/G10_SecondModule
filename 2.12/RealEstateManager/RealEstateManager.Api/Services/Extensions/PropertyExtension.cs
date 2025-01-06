using RealEstateManager.Api.DataAccess.Entities;
using RealEstateManager.Api.Services.DTOs;

namespace RealEstateManager.Api.Services.Extensions;

public static class PropertyExtension
{
    //public static Property ToProperty(this PropertyUpdateDto dto)
    //{
    //    return new Property
    //    {
    //        Price = dto.Price,
    //        Location = dto.Location,
    //        IsAvailable = dto.IsAvailable,
    //        Id = dto.Id,
    //        Name = dto.Name,
    //        Type = dto.Type
    //    };
    //}
    public static bool IsAffordable(this PropertyUpdateDto property, double budget)
    {
        if (property.Price <= budget)
        {
            return true;
        }
        return false;
    }

    public static bool IsLocatedIn(this PropertyUpdateDto property, string location)
    {
        if (property.Location == location)
        {
            return true;
        }
        return false;
    }

    public static string ToShortInfo(this PropertyUpdateDto property)
    {
        return $"Name: {property.Name}, Location: {property.Location}, Price: {property.Price}";
    }

    public static string ToDetailedInfo(this PropertyUpdateDto property)
    {
        return $"Id: {property.Id}, Name: {property.Name}, Location: {property.Location}, Price: {property.Price}, Type: {property.Type}, Is Available: {property.IsAvailable}\n";

    }

    public static bool IsOfType(this PropertyUpdateDto property, string type)
    {
        if (property.Type == type)
        {
            return true;
        }
        return false;
    }
}
