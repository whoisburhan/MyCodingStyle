using System;
using System.Collections.Generic;

public interface IToDoView
{
    // view -> presenter
    event Action<string> OnAddRequested;    // submit title
    event Action<string> OnToggleRequested; // item id
    event Action<string> OnDeletedRequested; // item id
    event Action<ToDoFilter> OnFilterChanged; // All/Active/Done

    // presenter -> view
    void RenderList(IReadOnlyList<ToDoItemVM> items);
    void SetEmptyState(bool isOn, string message);
    void SetInputError(string message); // "" hides

}
