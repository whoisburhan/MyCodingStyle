public sealed class ToDoItem
{
    public string Id { get; }
    public string Title { get; private set; }
    public bool IsDone { get; private set; }

    public ToDoItem(string id, string title, bool isDone)
    {
        Id = id;
        Title = title;
        IsDone = isDone;
    }

    public void ToggleDone()
    {
        IsDone = !IsDone;
    }
}
