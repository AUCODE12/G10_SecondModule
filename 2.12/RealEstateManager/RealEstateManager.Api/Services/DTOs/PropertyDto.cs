namespace RealEstateManager.Api.Services.DTOs;

public class PropertyDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public double Price { get; set; }
    public bool IsAvailable { get; set; }
    public string Type { get; set; }
}
