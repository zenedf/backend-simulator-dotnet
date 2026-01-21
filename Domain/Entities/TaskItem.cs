namespace BackendSimulator.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; set; }
    public string Title { get; private set; }

    public TaskItem(string title) =>
        Title = title;
}
