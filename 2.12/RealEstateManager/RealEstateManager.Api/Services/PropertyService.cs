using RealEstateManager.Api.DataAccess.Entities;
using RealEstateManager.Api.Repositories;
using RealEstateManager.Api.Services.DTOs;

namespace RealEstateManager.Api.Services;

public class PropertyService : IPropertyService
{
    private readonly IPropertyRepository _propertyRopesitory;

    public PropertyService()
    {
        _propertyRopesitory = new PropertyRepository();
    }

    public Guid AddProperty(PropertyDto propertyDto)
    {
        var id = _propertyRopesitory.WriteProperty(ConvertToEntity(propertyDto));
        return id;
    }

    public void DeleteProperty(Guid propertyId)
    {
        _propertyRopesitory.RemoveProperty(propertyId);
    }

    public List<PropertyUpdateDto> GetAllProperties()
    {
        var properties = _propertyRopesitory.ReadAllProperties();
        var propertyDtos = new List<PropertyUpdateDto>();
        foreach (var poperty in properties)
        {
            propertyDtos.Add(ConvertToDto(poperty));
        }
        return propertyDtos;
    }

    public List<PropertyUpdateDto> GetAvailableProperties()
    {
        var properties = _propertyRopesitory.ReadAllProperties();
        var propertyDtos = new List<PropertyUpdateDto>();
        foreach (var property in properties)
        {
            if (property.IsAvailable is true)
            {
                propertyDtos.Add(ConvertToDto(property));
            }
        }
        return propertyDtos;
    }

    public PropertyUpdateDto GetPropertyById(Guid propertyId)
    {
        var property = _propertyRopesitory.ReadPropertyById(propertyId);
        return ConvertToDto(property);
    }

    public List<PropertyUpdateDto> SearchByLocation(string location)
    {
        var properties = _propertyRopesitory.ReadAllProperties();
        var propertyDtos = new List<PropertyUpdateDto>();
        foreach (var property in properties)
        {
            if (property.Location == location)
            {
                propertyDtos.Add(ConvertToDto(property));
            }
        }
        return propertyDtos;
    }

    public List<PropertyUpdateDto> SortByPrice()
    {
        var properties = _propertyRopesitory.ReadAllProperties();
        var propertyDtos = new List<PropertyUpdateDto>();
        foreach (var property in properties)
        {
            propertyDtos.Add(ConvertToDto(property));
        }
        propertyDtos.Sort((x, y) => y.Price.CompareTo(x.Price));
        return propertyDtos;
    }

    public void UpdateProperty(PropertyUpdateDto propertyUpdateDto)
    {
        _propertyRopesitory.UpdateProperty(ConvertToEntity(propertyUpdateDto));
    }

    private Property ConvertToEntity(PropertyDto propertyDto)
    {
        return new Property
        {
            Id = Guid.NewGuid(),
            Type = propertyDto.Type,
            IsAvailable = propertyDto.IsAvailable,
            Location = propertyDto.Location,
            Name = propertyDto.Name,
            Price = propertyDto.Price,
        };
    }

    private Property ConvertToEntity(PropertyUpdateDto propertyUpdateDto)
    {
        return new Property
        {
            Id = propertyUpdateDto.Id,
            Type = propertyUpdateDto.Type,
            IsAvailable = propertyUpdateDto.IsAvailable,
            Location = propertyUpdateDto.Location,
            Name = propertyUpdateDto.Name,
            Price = propertyUpdateDto.Price,
        };
    }

    private PropertyUpdateDto ConvertToDto(Property property)
    {
        return new PropertyUpdateDto
        {
            Id = property.Id,
            Type = property.Type,
            IsAvailable = property.IsAvailable,
            Location = property.Location,
            Name = property.Name,
            Price = property.Price,
        };
    }
}
