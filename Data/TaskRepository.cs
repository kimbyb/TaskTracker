namespace TaskTracker.Models;

public class TaskRepository
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;
    
    public IReadOnlyList<TaskItem> GetAll() => _tasks;

    public void Add(string title)
    {
        _tasks.Add(new TaskItem
        {
            Id = _nextId++,
            Title = title
        });
    }

    public void ToggleOne(int id)
    {
        var task = _tasks.First(t => t.Id == id);
        task.IsDone = !task.IsDone;
    }

    public void Delete(int id)
    {
        var task = _tasks.First(t => t.Id == id);
        _tasks.Remove(task);
    }
}