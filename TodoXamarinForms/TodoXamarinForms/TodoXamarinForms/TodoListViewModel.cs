using System.Collections.Generic;
using System.Linq;

namespace TodoXamarinForms
{
    class TodoListViewModel : BaseFodyObservable
    {
        public TodoListViewModel()
        {
            GroupedTodoList = GetGroupedTodoList();
        }

        public ILookup<string, TodoItem> GroupedTodoList { get; set; }
        public string Title => "My Todo list";

        private List<TodoItem> _todoList = new List<TodoItem>
        {
            new TodoItem { Id = 0, Title = "Create First Todo", IsCompleted = true},
            new TodoItem { Id = 1, Title = "Run a Marathon"},
            new TodoItem { Id = 2, Title = "Create TodoXamarinForms blog post"},
        };

        private ILookup<string, TodoItem> GetGroupedTodoList()
        {
            return _todoList.OrderBy(t => t.IsCompleted).ToLookup(t => t.IsCompleted? "Completed" : "Active");
        }
    }
}
