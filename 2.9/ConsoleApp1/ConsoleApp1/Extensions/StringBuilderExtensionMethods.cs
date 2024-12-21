using System.Text;

namespace ConsoleApp1.Extensions;

public static class StringBuilderExtensionMethods
{
    public static int UpperLatterAmount(this StringBuilder text)
    {
        var count = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (char.IsUpper(text[i]))
            {
                count++;
            }
        }
        return count;
    }
}
