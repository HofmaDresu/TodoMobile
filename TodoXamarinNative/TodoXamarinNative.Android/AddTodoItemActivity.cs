using Android.App;
using Android.OS;

namespace TodoXamarinNative.Android
{
    [Activity(Label = "AddTodoItemActivity")]
    public class AddTodoItemActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.AddTodoItem);
        }
    }
}