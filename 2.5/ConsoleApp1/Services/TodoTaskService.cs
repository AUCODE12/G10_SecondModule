using ConsoleApp1.Models;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1.Services;

public class TodoTaskService : ITodoTaskService
{
    private string taskDataFilePath;
    private List<TodoTask> tasks;

    public TodoTaskService()
    {
        taskDataFilePath = "../../../Data/DataTasks.json";
        if (File.Exists(taskDataFilePath) is false)
        {
            File.WriteAllText(taskDataFilePath, "[]");
        } 

        tasks = new List<TodoTask>();
        tasks = GetAllTasks();
    }


    public TodoTask AddTask(TodoTask task)
    {
        task.Id = Guid.NewGuid();
        tasks.Add(task);
        SaveData();
        return task;
    }

    public bool DeleteTask(Guid deleteTaskId)
    {
        var hasTask = GetTaskById(deleteTaskId);
        if (hasTask is null)
        {
            return false;
        }
        tasks.Remove(hasTask);
        SaveData();
        return true;
    }

    public List<TodoTask> GetAllTasks()
    {
        return GetTasks();
    }

    public TodoTask GetTaskById(Guid id)
    {
        foreach (var task in tasks)
        {
            if (task.Id == id)
            {
                return task;
            }
        }

        return null;
    }

    public List<TodoTask> GetTasksByImportant(bool isImportant)
    {
        var checkImportantTasks = new List<TodoTask>();
        foreach (var task in tasks)
        {
            if (task.IsImportant == isImportant)
            {
                checkImportantTasks.Add(task);
            }
        }

        return checkImportantTasks;
    }

    public bool UpdateTask(TodoTask newTask)
    {
        var hasTask = GetTaskById(newTask.Id);
        if (hasTask is null)
        {
            return false;
        }
        var index = tasks.IndexOf(hasTask);
        tasks[index] = newTask;
        SaveData();
        return true;
    }

    private void SaveData()
    {
        var taskJson = JsonSerializer.Serialize(tasks);
        File.WriteAllText(taskDataFilePath, taskJson);
    }

    private List<TodoTask> GetTasks()
    {
        var tasksJson = File.ReadAllText(taskDataFilePath);
        var tasks = JsonSerializer.Deserialize<List<TodoTask>>(tasksJson);

        return tasks;
    }
}
