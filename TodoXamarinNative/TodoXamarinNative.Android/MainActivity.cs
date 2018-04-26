using Android.App;
using Android.Widget;
using Android.OS;
using System.Linq;
using TodoXamarinNative.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoXamarinNative.Android
{
    [Activity(Label = "TodoXamarinNative.Android", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private ListView _todoListView;
        private List<TodoItem> _todoList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            _todoListView = FindViewById<ListView>(Resource.Id.TodoList);
        }

        protected override async void OnResume()
        {
            base.OnResume();

            await UpdateTodoList();
        }

        private async Task UpdateTodoList()
        {
            _todoList = await MainApplication.TodoRepository.GetList();
            var adapter = new TodoAdapter(this, _todoList.OrderBy(t => t.IsCompleted).ToList());
            adapter.OnCompletedChanged += HandleItemCompletedChanged;
            _todoListView.Adapter = adapter;
        }

        private async void HandleItemCompletedChanged(object sender, int todoId)
        {
            var targetItem = _todoList.Single(t => t.Id == todoId);
            await MainApplication.TodoRepository.ChangeItemIsCompleted(targetItem);
            await UpdateTodoList();
        }
    }
}

