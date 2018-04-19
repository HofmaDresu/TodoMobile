using System.Collections.ObjectModel;

namespace TodoXamarinForms
{
    class TodoListViewModel : BaseFodyObservable
    {
        public string Title => "My Todo list";
        public ObservableCollection<TodoItem> TodoList { get; set; } = new ObservableCollection<TodoItem>
        {
            new TodoItem { Id = 0, Title = "Create First Todo", IsCompleted = true},
            new TodoItem { Id = 1, Title = "Run a Marathon"},
            new TodoItem { Id = 2, Title = "Create TodoXamarinForms blog post"},
        };
    }
}
