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

    public Test AddTest(Test test)
    {
        test.Id = Guid.NewGuid();
        var tests = GetTests();
        tests.Add(test);
        SaveData(tests);

        return test;
    }

    public Test GetTestById(Guid id)
    {
        var tests = GetTests();
        foreach (var test in tests)
        {
            if (test.Id == id) return test;
        }

        return null;
    }

    public List<Test> GetAllTests()
    {
        return GetTests();
    }

    public bool UpdateTest(Test newTest)
    {
        var tests = GetAllTests();
        var testFromDb = GetTestById(newTest.Id);
        if (testFromDb is null)
        {
            return false;
        }
        for (var i = 0; i < tests.Count; i++)
        {
            if (tests[i].Id == newTest.Id)
            {
                tests[i] = newTest;
                break;
            }
        }
        SaveData(tests);
        
        return true;
    }

    public bool DeleteTest(Guid testId)
    {
        var tests = GetTests();
        var testFromDb = GetTestById(testId);
        if (testFromDb is null)
        {
            return false;
        }
        foreach (var test in tests)
        {
            if (test.Id == testId)
            {
                tests.Remove(test);
                break;
            }
        }
        SaveData(tests);

        return true;
    }

    public List<Test> GetRandomTest(int amount)
    {
        var tests = GetTests();
        var getAmountListTests = new List<Test>();
        for (var i = 0; i < amount; i++)
        {
            var index = new Random().Next(0, tests.Count);
            getAmountListTests.Add(tests[index]);
        }

        return getAmountListTests;
    }

    public int GetAmountTests()
    {
        return GetTests().Count;
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
