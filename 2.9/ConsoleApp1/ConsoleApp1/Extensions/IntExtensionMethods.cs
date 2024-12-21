namespace ConsoleApp1.Extensions;

public static class IntExtensionMethods
{
    public static bool IsEven(this int num)
    {
        if (num % 2 == 0)
        {
            return true;
        }
        return false;
    }

    public static bool IsPrime(this int num)
    {
        var count = 0;
        for (int i = 1; i <= num; i++)
        {
            if (num % i == 0)
            {
                count++;
            }
        }
        if (count == 2)
        {
            return true;
        }
        return false;
    }

    public static void DecreaseValue(this ref int number, int value)
    {
        number += value;
    }
}