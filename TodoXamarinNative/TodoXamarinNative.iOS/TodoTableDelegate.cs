using System;
using Foundation;
using TodoXamarinNative.Core;
using UIKit;

namespace TodoXamarinNative.iOS
{
    class TodoTableDelegate : UITableViewDelegate
    {
        public EventHandler<TodoItem> OnIsCompletedToggled;
        public EventHandler<TodoItem> OnTodoDeleted;

        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            var source = tableView.Source as TodoItemTableSource;
            var selectedItem = source.GetItem(indexPath);

            UITableViewRowAction editButton = UITableViewRowAction.Create(
                UITableViewRowActionStyle.Normal,
                selectedItem.IsCompleted ? "Uncomplete" : "Complete",
                (arg1, arg2) => OnIsCompletedToggled?.Invoke(this, selectedItem));
            UITableViewRowAction deleteButton = UITableViewRowAction.Create(
                UITableViewRowActionStyle.Destructive,
                "Delete",
                (arg1, arg2) => OnTodoDeleted?.Invoke(this, selectedItem));
            return new UITableViewRowAction[] { deleteButton, editButton };
        }
    }
}
