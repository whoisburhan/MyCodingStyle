using System.Collections.Generic;

public interface IToDoRepository
{
    IReadOnlyList<ToDoItem> GetAll();
    void Add(ToDoItem item);
    ToDoItem FindById(string id);
    void Remove(string id);
    void Clear();
}
