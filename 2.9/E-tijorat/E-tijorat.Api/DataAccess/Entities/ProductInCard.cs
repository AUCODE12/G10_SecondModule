namespace E_tijorat.Api.DataAccess.Entities;

public class ProductInCard
{
    public Guid ProductId { get; set; }
    public Guid UserId { get; set; }
    public string ProductName { get; set; }
    public int ProductAmount { get; set; }
}
