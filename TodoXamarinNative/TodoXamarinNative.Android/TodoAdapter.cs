using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TodoXamarinNative.Core;

namespace TodoXamarinNative.Android
{
    class TodoAdapter : BaseAdapter
    {
        Context context;
        private List<TodoItem> _todoItems;

        public TodoAdapter(Context context, List<TodoItem> todoItems)
        {
            this.context = context;
            _todoItems = todoItems;
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            TodoAdapterViewHolder holder = null;

            if (view != null)
                holder = view.Tag as TodoAdapterViewHolder;

            if (holder == null)
            {
                holder = new TodoAdapterViewHolder();
                var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();

                view = inflater.Inflate(Resource.Layout.TodoListItem, parent, false);
                holder.Title = view.FindViewById<TextView>(Resource.Id.TodoTitle);
                holder.IsCompleted = view.FindViewById<CheckBox>(Resource.Id.TodoIsCompleted);
                view.Tag = holder;
            }

            var currentTodoItem = _todoItems[position];
            holder.Title.Text = currentTodoItem.Title;
            holder.IsCompleted.Checked = currentTodoItem.IsCompleted;

            return view;
        }
        
        public override int Count
        {
            get
            {
                return _todoItems.Count;
            }
        }

    }

    class TodoAdapterViewHolder : Java.Lang.Object
    {
        public TextView Title { get; set; }
        public CheckBox IsCompleted { get; set; }
    }
}