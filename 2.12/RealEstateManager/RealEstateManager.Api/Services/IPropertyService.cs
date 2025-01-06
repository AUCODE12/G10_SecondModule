using RealEstateManager.Api.Services.DTOs;

namespace RealEstateManager.Api.Services;

public interface IPropertyService
{
    Guid AddProperty(PropertyDto propertyDto);

    List<PropertyUpdateDto> GetAllProperties();

    PropertyUpdateDto GetPropertyById(Guid propertyId);

    void UpdateProperty(PropertyUpdateDto propertyUpdateDto);

    void DeleteProperty(Guid propertyId);

    List<PropertyUpdateDto> GetAvailableProperties();

    List<PropertyUpdateDto> SearchByLocation(string location);

    List<PropertyUpdateDto> SortByPrice();
}