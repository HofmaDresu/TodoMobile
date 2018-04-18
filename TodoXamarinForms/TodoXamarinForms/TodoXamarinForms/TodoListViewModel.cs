using MvvmHelpers;
using System.Collections.ObjectModel;

namespace TodoXamarinForms
{
    public class TodoListViewModel : BaseViewModel
    {
        public ObservableCollection<TodoItem> TodoList { get; set; } = new ObservableCollection<TodoItem>
        {
            new TodoItem { Id = 0, Title = "Create First Todo", IsCompleted = true},
            new TodoItem { Id = 1, Title = "Run a Marathon"},
            new TodoItem { Id = 2, Title = "Create TodoXamarinForms blog post"},
        };
    }
}
