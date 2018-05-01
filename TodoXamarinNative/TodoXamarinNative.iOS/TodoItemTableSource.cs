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
        private IEnumerable<TodoItem> _activeItems => _todoItems.Where(t => !t.IsCompleted);
        private IEnumerable<TodoItem> _completedItems => _todoItems.Where(t => t.IsCompleted);

        public TodoItemTableSource(List<TodoItem> todoItems)
        {
            _todoItems = todoItems.OrderBy(t => t.IsCompleted).ToList();
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
            cell.TextLabel.Text = GetItem(indexPath).Title;
            return cell;
        }

        public TodoItem GetItem(NSIndexPath indexPath)
        {
            var releventList = indexPath.Section == 0 ? _activeItems : _completedItems;
            return releventList.ToList()[indexPath.Row];
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _todoItems.Count(t => t.IsCompleted == (section == 1));
        }

        public override nint NumberOfSections(UITableView tableView) => 2;

        public override string TitleForHeader(UITableView tableView, nint section) => section == 0 ? "Active" : "Completed";
        
        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
        }
    }
}
