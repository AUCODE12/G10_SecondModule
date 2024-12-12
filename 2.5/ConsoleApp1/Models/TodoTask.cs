namespace ConsoleApp1.Models;

public class TodoTask
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? DueDate { get; set; } 

    public bool IsImportant { get; set; }      

    public TaskStatus Status { get; set; }
}
