using ConsoleApp1.MyList1;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        FirstMyList<int> firstMyList = new FirstMyList<int>();
        firstMyList.AddItem(15);
        firstMyList.AddItem(65);
        firstMyList.AddItem(29);
        firstMyList.AddItem(40);
        firstMyList.AddItem(73);
        //Console.WriteLine(firstMyList.GetItemAt(0));
        //Console.WriteLine(firstMyList.GetItemAt(1));
        //Console.WriteLine(firstMyList.GetItemAt(2));
        //Console.WriteLine(firstMyList.GetItemAt(3));
        //Console.WriteLine(firstMyList.GetItemAt(4));

        var arr = firstMyList.ToArray();

        Console.WriteLine(arr[0]);
        Console.WriteLine(arr[1]);
        Console.WriteLine(arr[2]);
        Console.WriteLine(arr[3]);
        Console.WriteLine(arr[4]);

    }
}
