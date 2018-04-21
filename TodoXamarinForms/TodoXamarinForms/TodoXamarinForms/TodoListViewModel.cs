using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TodoXamarinForms
{
    class TodoListViewModel : BaseFodyObservable
    {
        public TodoListViewModel()
        {
            GroupedTodoList = GetGroupedTodoList();
            Delete = new Command<TodoItem>(HandleDelete);
            ChangeIsCompleted = new Command<TodoItem>(HandleChangeIsCompleted);
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

        public Command<TodoItem> Delete { get; set; }
        public void HandleDelete(TodoItem itemToDelete)
        {
            // Remove item from private list
            _todoList.Remove(itemToDelete);
            // Update displayed list
            GroupedTodoList = GetGroupedTodoList();
        }
        
        public Command<TodoItem> ChangeIsCompleted { get; set; }
        public void HandleChangeIsCompleted(TodoItem itemToUpdate)
        {
            // Change item's IsCompleted flag
            itemToUpdate.IsCompleted = !itemToUpdate.IsCompleted;
            // Update displayed list
            GroupedTodoList = GetGroupedTodoList();
        }
        
    }
}
