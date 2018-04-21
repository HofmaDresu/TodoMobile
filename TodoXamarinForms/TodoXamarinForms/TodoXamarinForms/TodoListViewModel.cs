using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoXamarinForms
{
    class TodoListViewModel : BaseFodyObservable
    {
        public TodoListViewModel()
        {
            GetGroupedTodoList().ContinueWith(t =>
            {
                GroupedTodoList = t.Result;
            });
            Delete = new Command<TodoItem>(HandleDelete);
            ChangeIsCompleted = new Command<TodoItem>(HandleChangeIsCompleted);
        }

        public ILookup<string, TodoItem> GroupedTodoList { get; set; }
        public string Title => "My Todo list";

        private async Task<ILookup<string, TodoItem>> GetGroupedTodoList()
        {
            return (await App.TodoRepository.GetList())
                             .OrderBy(t => t.IsCompleted)
                             .ToLookup(t => t.IsCompleted? "Completed" : "Active");
        }

        public Command<TodoItem> Delete { get; set; }
        public async void HandleDelete(TodoItem itemToDelete)
        {
            await App.TodoRepository.DeleteItem(itemToDelete);
            // Update displayed list
            GroupedTodoList = await GetGroupedTodoList();
        }
        
        public Command<TodoItem> ChangeIsCompleted { get; set; }
        public async void HandleChangeIsCompleted(TodoItem itemToUpdate)
        {
            await App.TodoRepository.ChangeItemIsCompleted(itemToUpdate);
            // Update displayed list
            GroupedTodoList = await GetGroupedTodoList();
        }
        
    }
}
