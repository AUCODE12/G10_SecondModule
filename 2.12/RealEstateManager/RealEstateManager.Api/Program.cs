using RealEstateManager.Api.Services;
using RealEstateManager.Api.Services.DTOs;
using RealEstateManager.Api.Services.Extensions;

namespace RealEstateManager.Api;

internal class Program
{
    static void Main(string[] args)
    {
        //var property1 = new PropertyDto
        //{
        //    IsAvailable = true,
        //    Location = "Navoi",
        //    Name = "Ltyr",
        //    Price = 1000,
        //    Type = "Office",
        //};

        //var property2 = new PropertyDto
        //{
        //    IsAvailable = false,
        //    Location = "Buxoro",
        //    Name = "asda",
        //    Price = 900,
        //    Type = "Uy",
        //};

        //var property3 = new PropertyDto
        //{
        //    IsAvailable = true,
        //    Location = "Toshkent",
        //    Name = "ghjgf",
        //    Price = 1500,
        //    Type = "Tijorat binosi",
        //};

        IPropertyService propertyService = new PropertyService();

        //propertyService.AddProperty(property1);
        //propertyService.AddProperty(property2);
        //propertyService.AddProperty(property3);

        //propertyService.DeleteProperty(Guid.Parse("5ce089df-0dd0-4bf4-a043-4488af05ba89"));
        //propertyService.DeleteProperty(Guid.Parse("d12780b5-9163-4123-8a5a-eb62e6e21f78"));
        //propertyService.DeleteProperty(Guid.Parse("24370a9f-51bb-400b-9827-1aa8c4c942d7"));

        var a = 1000d;

        var properties = propertyService.GetAllProperties();

        foreach (var property in properties)
        {
            Console.WriteLine(property.ToDetailedInfo());
        }


    }
}
