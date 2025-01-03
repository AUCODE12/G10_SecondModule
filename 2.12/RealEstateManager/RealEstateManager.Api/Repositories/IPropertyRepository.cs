using RealEstateManager.Api.DataAccess.Entities;

namespace RealEstateManager.Api.Repositories;

public interface IPropertyRepository
{
    Guid WriteProperty(Property property);

    List<Property> ReadAllProperties();

    Property ReadPropertyById(Guid id);

    void UpdateProperty(Property property);

    void DeleteProperty(Guid id);
}