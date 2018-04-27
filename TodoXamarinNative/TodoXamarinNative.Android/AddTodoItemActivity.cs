using Android.App;
using Android.OS;
using Android.Widget;
using System;
using TodoXamarinNative.Core;

namespace TodoXamarinNative.Android
{
    [Activity(Label = "Add Todo Item")]
    public class AddTodoItemActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddTodoItem);

            FindViewById<Button>(Resource.Id.CancelButton).Click += (s, e) => Finish();
            FindViewById<Button>(Resource.Id.SaveButton).Click += HandleSave;
        }

        private async void HandleSave(object s, EventArgs e)
        {
            var todoText = FindViewById<EditText>(Resource.Id.TodoTitle).Text;
            await MainApplication.TodoRepository.AddItem(new TodoItem { Title = todoText });
            Finish();
        }
    }
}