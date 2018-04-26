using Android.App;
using Android.Widget;
using Android.OS;
using GoogleAndroid = Android;
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
            var adapter = new ArrayAdapter<string>(this, GoogleAndroid.Resource.Layout.SimpleListItem1, todoList.Select(t => t.Title).ToArray());
            _todoList.Adapter = adapter;
        }
    }
}

