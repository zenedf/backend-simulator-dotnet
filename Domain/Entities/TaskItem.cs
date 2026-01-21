namespace BackendSimulator.Domain.Entities;

public class TaskItem
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; private set; }

    public TaskItem(string title) =>
        Title = title;
}
