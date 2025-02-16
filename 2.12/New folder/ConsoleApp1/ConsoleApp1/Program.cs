using System.Collections;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {

        // Generic
        LinkedList<int> linkedList = new LinkedList<int>();
        // bir biriga bog'langan elementlar ro'yxati
        linkedList.AddLast(1);

        SortedSet<int> sortedSet = new SortedSet<int>();
        // Sortlangan va unik saqalandigan ro'yxat

        HashSet<int> hashSet = new HashSet<int>();
        SortedList<int, string> keyValuePairs = new SortedList<int, string>();
        List<int> list = new List<int>();
        Queue<int> queue = new Queue<int>();
        Stack<int> stack = new Stack<int>();


        // Non Generic
        ArrayList arrayList = new ArrayList();
        Hashtable hashtable = new Hashtable();
        Queue queue1 = new Queue();
        Stack stack1 = new Stack();
        SortedList sortedList = new SortedList();
    }
}
