namespace ConsoleApp1.Models;

public class ShoppingCart
{
    private List<Product> _products;

    public ShoppingCart()
    {
        _products = new List<Product>();
    }

    public Product AddToCart(Product product)
    {
        _products.Add(product);
        return product;
    }

    public double CalculateTotalPrice()
    {
        var total = 0d;
        foreach (var product in _products)
        {
            total += product.Price;
        }

        return total;
    }
}
