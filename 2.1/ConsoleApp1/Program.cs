using ConsoleApp1.Models;
using ConsoleApp1.Services;
using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("salom");
            Console.WriteLine(sb);

            var mySb = new MyStringBuilderService();
            mySb.MyAppend("Salom");
            mySb.MyAppend("Hello");
            mySb.MyAppend("C#");
            mySb.GetAll();


        }
    }
}
