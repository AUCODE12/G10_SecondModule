using E_tijorat.Api.DataAccess.Entities;

namespace E_tijorat.Api.Repositories;

public interface IAdmistratorPanelRepository
{
    Guid WriteProduct(Product product);

    void UpdateProduct(Product updateProduct);

    void DeleteProduct(Guid productId);

    List<Product> ReadProducts();

    Product ReadProductById(Guid productId);
}