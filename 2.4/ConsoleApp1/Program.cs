namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            int.TryParse(Console.ReadLine(), out number);
            Console.WriteLine(number);
        }
    }
}
