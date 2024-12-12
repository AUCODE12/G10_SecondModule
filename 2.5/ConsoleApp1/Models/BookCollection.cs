namespace ConsoleApp1.Models;

public class BookCollection
{
    private List<Book> Books;

    public BookCollection()
    {
        Books = new List<Book>();
    }

    public Book AddBook(Book book)
    {
        Books.Add(book);
        return book;
    }

    public Book GetBooksByAuthor(string author)
    {
        foreach (var book in Books)
        {
            if (book.Author == author)
            {
                return book;
            }
        }

        return null;
    }
}
