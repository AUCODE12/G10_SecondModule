using RealEstateManager.Api.DataAccess.Entities;
using System.Text.Json;

namespace RealEstateManager.Api.Repositories;

public class PropertyRepository : IPropertyRepository
{
    private readonly string _path;
    private readonly List<Property> _properties;

    public PropertyRepository()
    {
        _path = "../../../DataAccess/Data/Propertys.json";
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }

        _properties = ReadAllProperties();
    }

    public void RemoveProperty(Guid id)
    {
        var fromDb = ReadPropertyById(id);
        _properties.Remove(fromDb);
        SaveDate();
    }

    public List<Property> ReadAllProperties()
    {
        var propertyJson = File.ReadAllText(_path);
        var properties = JsonSerializer.Deserialize<List<Property>>(propertyJson);
        return properties;
    }

    public Property ReadPropertyById(Guid id)
    {
        foreach (var property in _properties)
        {
            if (property.Id == id) return property;
        }

        throw new Exception("Bunday malumot mavjud emas!");
    }

    public void UpdateProperty(Property property)
    {
        var fromDb = ReadPropertyById(property.Id);
        var index = _properties.IndexOf(fromDb);
        _properties[index] = property;
        SaveDate();
    }

    public Guid WriteProperty(Property property)
    {
        _properties.Add(property);
        SaveDate();
        return property.Id;
    }

    private void SaveDate()
    {
        var propertyJson = JsonSerializer.Serialize(_properties);
        File.WriteAllText(_path, propertyJson);
    }
}
