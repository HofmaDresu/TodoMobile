using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using TodoXamarinNative.Core;
using UIKit;

namespace TodoXamarinNative.iOS
{
    class TodoItemTableSource : UITableViewSource
    {
        private const string CellIdentifier = "TodoItemCell";
        private readonly List<TodoItem> _todoItems;

        public TodoItemTableSource(List<TodoItem> todoItems)
        {
            _todoItems = todoItems.OrderBy(t => t.IsCompleted).ToList();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            cell.TextLabel.Text = _todoItems[indexPath.Row].Title;
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _todoItems.Count(t => t.IsCompleted == (section == 1));
        }

        public override nint NumberOfSections(UITableView tableView) => 2;

        public override string TitleForHeader(UITableView tableView, nint section) => section == 0 ? "Active" : "Completed";

    }
}
