using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoXamarinForms
{
    class TodoListViewModel : BaseFodyObservable
    {
        public TodoListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            GetGroupedTodoList().ContinueWith(t =>
            {
                GroupedTodoList = t.Result;
            });
            Delete = new Command<TodoItem>(HandleDelete);
            ChangeIsCompleted = new Command<TodoItem>(HandleChangeIsCompleted);
            AddItem = new Command(HandleAddItem);
        }

        private INavigation _navigation;
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

        public Command AddItem { get; set; }
        public async void HandleAddItem()
        {
            await _navigation.PushModalAsync(new AddTodoItem());
        }

        public async Task RefreshTaskList()
        {
            GroupedTodoList = await GetGroupedTodoList();
        }
    }
}
