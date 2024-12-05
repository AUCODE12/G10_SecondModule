namespace ConsoleApp1.Services;

public class MyStringBuilderService
{
    public List<string> strings;

    public MyStringBuilderService()
    {
        strings = new List<string>();
    }

    public string MyAppend(string str)
    {
        strings.Add(str);

        return str;
    }

    public void GetAll()
    {
        foreach (var item in strings)
        {
            Console.Write(item);
        }
    }
}
