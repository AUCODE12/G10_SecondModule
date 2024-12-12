using ConsoleApp1.Models;

namespace ConsoleApp1.Services;

public interface ITodoTaskService
{
    TodoTask AddTask(TodoTask task);

    List<TodoTask> GetAllTasks();

    bool UpdateTask(TodoTask newTask);

    bool DeleteTask(Guid deleteTaskId);

    TodoTask GetTaskById(Guid id);

    List<TodoTask> GetTasksByImportant(bool isImportant);
}