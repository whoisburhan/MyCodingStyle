public readonly struct ToDoItemVM
{
    public readonly string id;
    public readonly string title;
    public readonly bool isDone;

    public ToDoItemVM(string id, string title, bool isDone)
    {
        this.id = id;
        this.title = title;
        this.isDone = isDone;
    }
}
