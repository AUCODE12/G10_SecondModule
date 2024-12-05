using ConsoleApp1.Models;
using System.Text.Json;

namespace ConsoleApp1.Services;

public class TestService
{
    private string testFilePath;

    public TestService()
    {
        testFilePath = "../../../Data/Tests.json";
        if (File.Exists(testFilePath) is false)
        {
            File.WriteAllText(testFilePath, "[]");
        }
    }

    private void SaveData(List<Test> tests)
    {
        var testsJson = JsonSerializer.Serialize(tests);
        File.WriteAllText(testFilePath, testsJson);
    }

    private List<Test> GetTests()
    {
        var testsJson = File.ReadAllText(testFilePath);
        var tests = JsonSerializer.Deserialize<List<Test>>(testsJson);

        return tests;
    }
}
