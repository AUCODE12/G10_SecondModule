using ConsoleApp1.Models;

namespace ConsoleApp1.Services;

public interface ITestService
{
    public Test AddTest(Test test);

    public Test GetById(Guid testId);

    public bool DeleteTest(Guid testId);

    public bool UpdateTest(Test test);

    public List<Test> GetAllTests();

    public List<Test> GetRandomTests(int count);
}