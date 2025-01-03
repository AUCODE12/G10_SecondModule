using System.Runtime.InteropServices;

namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(IsValid("({[)]}"));
    }

    public static int RomanToInt(string s)
    {
        Dictionary<string, int> romanInt = new Dictionary<string, int>
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };
        var integer = 0;
        for (int i = 0; i < s.Length; i++)
        {
            int current = romanInt[s[i].ToString()];

            int next = (i + 1 < s.Length) ? romanInt[s[i + 1].ToString()] : 0;

            if (current < next)
            { 
                integer -= current;
            }
            else
            { 
                integer += current;
            }
        }
        return integer;
    }

    public static int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        Array.Sort(nums);

        int uniqueCount = 1; 

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                nums[uniqueCount] = nums[i]; 
                uniqueCount++;
            }
        }

        return uniqueCount; 
    }

    public static bool IsValid(string s)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char ch in s)
        {
            if (ch == '(' || ch == '{' || ch == '[')
            {
                stack.Push(ch);
            }
            else if (ch == ')' || ch == '}' || ch == ']')
            {
                if (stack.Count == 0)
                {
                    return false;
                }
                char top = stack.Pop();
                if (!((top == '(' && ch == ')') || (top == '{' && ch == '}') || (top == '[' && ch == ']')))
                {         
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}
