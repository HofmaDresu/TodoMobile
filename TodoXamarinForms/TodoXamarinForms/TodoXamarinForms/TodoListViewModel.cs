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

        private ILookup<string, TodoItem> GetGroupedTodoList()
        {
            return App.TodoRepository.GetList().OrderBy(t => t.IsCompleted).ToLookup(t => t.IsCompleted? "Completed" : "Active");
        }

        public Command<TodoItem> Delete { get; set; }
        public void HandleDelete(TodoItem itemToDelete)
        {
            App.TodoRepository.DeleteItem(itemToDelete);
            // Update displayed list
            GroupedTodoList = GetGroupedTodoList();
        }
        
        public Command<TodoItem> ChangeIsCompleted { get; set; }
        public void HandleChangeIsCompleted(TodoItem itemToUpdate)
        {
            App.TodoRepository.ChangeItemIsCompleted(itemToUpdate);
            // Update displayed list
            GroupedTodoList = GetGroupedTodoList();
        }
        
    }
}
