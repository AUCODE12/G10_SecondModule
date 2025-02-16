namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {

    }

    public static int MajorityElement(int[] nums)
    {
        var m = 0;
        var c = 0;

        foreach (var x in nums)
        {
            if (c == 0)
            {
                m = x;
                c = 1;
            }
            else if (m == x)
            {
                c++;
            }
            else
            {
                c--;
            }
        }

        return m;
    }

    public static int LengthOfLastWord(string s)
    {
        var count = 0;
        var sT = s.TrimEnd();
        for (int i = sT.Length - 1; i >= 0; i--)
        {
            if (sT[i] == ' ') break;
            count++;
        }
        return count;
    }

    public static int StrStr(string haystack, string needle)
    {
        return haystack.IndexOf(needle);
    }

    public static bool IsPalindrome(string s)
    {
        return true;
    }//

    //public string AddBinary(string a, string b)
    //{}

    public static int MySqrt(int x)
    {
        if (x == 0) return 0;

        int l = 1;
        int r = x;
        
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            int sqrt = x / m;
            if (sqrt == m)
            {
                return m;
            }
            else if (sqrt < m)
            {
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }
        return r;
    }

    public static double MyPow(double x, int n)
    {
        double res = 1;
        for (int i = 0; i < n; i++)
        {
            res *= x;
        }
        return res;

        //return Math.Pow(x, n);
    }

    //public static ListNode MergeTwoLists(ListNode headA, ListNode headB)
    //{
    //}
}
