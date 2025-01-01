using System.Collections;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        Queue queue1 = new Queue();

        queue1.Enqueue(new test());
        Console.WriteLine(queue1.Dequeue());
    }
}
