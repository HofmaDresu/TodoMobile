using UIKit;

namespace TodoXamarinNative.iOS
{
    class MainViewController : UIViewController
    {
        private UITableView _todoTableView;

        public MainViewController()
        {
            Title = "Todo List";
            View.BackgroundColor = UIColor.White;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _todoTableView = new UITableView
            {
                TranslatesAutoresizingMaskIntoConstraints = false
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

            var todoList = await AppDelegate.TodoRepository.GetList();
            _todoTableView.Source = new TodoItemTableSource(todoList);
            _todoTableView.ReloadData();
        }
    }
}
