namespace RealEstateManager.Api.DataAccess.Entities;

public class Property
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public double Price { get; set; }
    public bool IsAvailable { get; set; }
    public string Type { get; set; }
}
//Type(Uy, Ofis, Tijorat binosi) enum
