using ConsoleApp1.Extensions;
using ConsoleApp1.Models;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        var book1 = new Book
        {
            Price = 40,
            Name = "Telba"
        };

        var book2 = new Book
        {
            Price = 401,
            Name = "Telba"
        };

        var book3 = new Book
        {
            Price = 40,
            Name = "Telba"
        };

        List<Book> list = new List<Book>();
        list.Add(book1);
        list.Add(book2);
        list.Add(book3);

        Console.WriteLine(list.TotalPrice());
        
    }
}
