using Android.App;
using Android.Widget;
using Android.OS;
using System.Linq;

namespace TodoXamarinNative.Android
{
    [Activity(Label = "TodoXamarinNative.Android", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private ListView _todoList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            _todoList = FindViewById<ListView>(Resource.Id.TodoList);
        }

        protected override async void OnResume()
        {
            base.OnResume();

            var todoList = await MainApplication.TodoRepository.GetList();
            var adapter = new TodoAdapter(this, todoList.OrderBy(t => t.IsCompleted).ToList());
            _todoList.Adapter = adapter;
        }
    }
}

