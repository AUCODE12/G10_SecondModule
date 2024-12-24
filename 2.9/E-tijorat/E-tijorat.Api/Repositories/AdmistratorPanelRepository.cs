using E_tijorat.Api.DataAccess.Entities;
using System.Text.Json;

namespace E_tijorat.Api.Repositories;

public class AdmistratorPanelRepository : IAdmistratorPanelRepository
{
    private readonly string _path;
    private List<Product> _products;

    public AdmistratorPanelRepository()
    {
        _path = "../../../DataAccess/Data/Products.json";
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _products = new List<Product>();
        _products = ReadProducts();
    }

    public void DeleteProduct(Guid productId)
    {
        var product = ReadProductById(productId);
        _products.Remove(product);
        SaveData();
    }

    public Product ReadProductById(Guid productId)
    {
        foreach (var product in _products)
        {
            if (product.Id == productId)
            {
                return product;
            }
        }

        throw new KeyNotFoundException($"Mahsulot ID {productId} topilmadi.");
    }

    public List<Product> ReadProducts()
    {
        var productsJson = File.ReadAllText(_path);
        var products = JsonSerializer.Deserialize<List<Product>>(productsJson);

        return products;
    }

    public void UpdateProduct(Product updateProduct)
    {
        var product = ReadProductById(updateProduct.Id);
        var index = _products.IndexOf(product);
        _products[index] = product;
        SaveData();
    }

    public Guid WriteProduct(Product product)
    {
        _products.Add(product);
        SaveData();
        return product.Id;
    }

    private void SaveData()
    {
        var productsJson = JsonSerializer.Serialize(_products);
        File.WriteAllText(_path, productsJson);
    }
}
