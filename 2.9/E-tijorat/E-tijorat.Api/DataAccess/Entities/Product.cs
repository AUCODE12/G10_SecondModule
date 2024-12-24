namespace E_tijorat.Api.DataAccess.Entities;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public string Description { get; set; }  // Mahsulot haqida tavsif

    public int Stock { get; set; }          // Ombordagi miqdor

    public string Category { get; set; }    // Mahsulot kategoriyasi

    public bool IsActive { get; set; }      // Aktivlik holati
}
