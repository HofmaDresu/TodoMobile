using System.Threading.Tasks;
using TodoXamarinNative.Core;
using UIKit;

namespace TodoXamarinNative.iOS
{
    class MainViewController : UIViewController
    {
        private UITableView _todoTableView;
        private TodoTableDelegate _todoTableDelegate;

        public MainViewController()
        {
            Title = "Todo List";
            View.BackgroundColor = UIColor.White;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _todoTableDelegate = new TodoTableDelegate();

            _todoTableView = new UITableView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            };
            View.Add(_todoTableView);

            _todoTableView.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            _todoTableView.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;
            _todoTableView.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            _todoTableView.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
        }

        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            await PopulateTable();
            _todoTableDelegate.OnIsCompletedToggled += HandleIsCompletedToggled;
            _todoTableDelegate.OnTodoDeleted += HandleTodoDeleted;
        }

        private async Task PopulateTable()
        {
            var todoList = await AppDelegate.TodoRepository.GetList();
            _todoTableView.Source = new TodoItemTableSource(todoList);
            _todoTableView.Delegate = _todoTableDelegate;
            _todoTableView.ReloadData();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            _todoTableDelegate.OnIsCompletedToggled -= HandleIsCompletedToggled;
            _todoTableDelegate.OnTodoDeleted -= HandleTodoDeleted;
        }

        private async void HandleIsCompletedToggled(object sender, TodoItem targetItem)
        {
            await AppDelegate.TodoRepository.ChangeItemIsCompleted(targetItem);
            await PopulateTable();
        }

        private async void HandleTodoDeleted(object sender, TodoItem targetItem)
        {
            await AppDelegate.TodoRepository.DeleteItem(targetItem);
            await PopulateTable();
        }
    }
}
