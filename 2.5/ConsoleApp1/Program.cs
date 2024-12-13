using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        // TO-DO
        RunFrontEnd();
    }

    public static void RunFrontEnd()
    {
        var todoTaskService = new TodoTaskService();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Get Task");
            Console.WriteLine("3. Update Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Get By Id Task");
            Console.WriteLine();
            Console.Write("Choose: ");
            var option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.Clear();
                var todoTask = new TodoTask();
                Console.Write("Add Task\n\n");
                
                Console.Write("Title: ");
                todoTask.Title = Console.ReadLine();
                
                Console.Write("Description: ");
                todoTask.Description = Console.ReadLine();
                
                Console.Write("Created Date: ");
                todoTask.CreatedDate = DateTime.Today;
                
                Console.Write("Due Date (yyyy-MM-dd): ");
                todoTask.DueDate = DateTime.Parse(Console.ReadLine());

                Console.Write("Is Important (true/false): ");
                todoTask.IsImportant = bool.Parse(Console.ReadLine());
                
                Console.Write("Status (0 = Completed, 1 = InProgress, 2 = Pending): ");
                todoTask.Status = (TaskStatus)int.Parse(Console.ReadLine());
            
                var request = todoTaskService.AddTask(todoTask);

                if (todoTask == request)
                {
                    Console.WriteLine("\n\nAdded");
                }
                else
                {
                    Console.WriteLine("Not Added");
                }
            }
            else if (option == 2)
            {

            }
            else if (option == 3)
            {

            }
            else if (option == 4)
            {

            }
            else if (option == 5)
            {

            }

            Console.ReadLine();
        }
    }
}























//Book book = new Book();
//BookCollection collection = new BookCollection();

//book.Author = "Rahimjon";
//book.Title = "Title";

//collection.AddBook(book);

//Console.WriteLine(collection.GetBooksByAuthor("Rahimjon").Author);
//Console.WriteLine(collection.GetBooksByAuthor("Rahimjon").Title);