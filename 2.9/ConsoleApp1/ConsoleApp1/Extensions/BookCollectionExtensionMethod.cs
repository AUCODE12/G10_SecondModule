using ConsoleApp1.Models;

namespace ConsoleApp1.Extensions;

public static class BookCollectionExtensionMethod
{
    public static double TotalPrice(this List<Book> books)
    {
        double totalPrice = 0;
        foreach (var book in books)
        {
            totalPrice += book.Price;
        }
        return totalPrice;
    }
}
