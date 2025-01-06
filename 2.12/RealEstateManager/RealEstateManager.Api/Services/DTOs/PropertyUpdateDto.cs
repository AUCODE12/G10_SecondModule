namespace RealEstateManager.Api.Services.DTOs;

public class PropertyUpdateDto : PropertyDto, IComparable<PropertyUpdateDto>
{
    public Guid Id { get; set; }

    public int CompareTo(PropertyUpdateDto other)
    {
        return Price.CompareTo(other.Price); // Narx bo‘yicha taqqoslaydi
    }
}
