using TodoXamarinNative.Core;
using UIKit;

namespace TodoXamarinNative.iOS
{
    class AddTodoItemViewController : UIViewController
    {
        private UITextField _todoTitleView;
        private UIButton _saveButton;
        private UIButton _cancelButton;

        public AddTodoItemViewController()
        {
            Title = "Add Todo Item";
            View.BackgroundColor = UIColor.White;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Use a container view to easily center our components on the screen
            var containerView = new UIView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            };

            View.Add(containerView);

            containerView.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            containerView.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
            containerView.WidthAnchor.ConstraintEqualTo(View.WidthAnchor, .7f).Active = true;

            _todoTitleView = new UITextField
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                Placeholder = "Enter Todo Title",
            };
            containerView.Add(_todoTitleView);
            _todoTitleView.BecomeFirstResponder();

            _cancelButton = new UIButton(UIButtonType.System)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            };
            _cancelButton.SetTitle("Cancel", UIControlState.Normal);
            containerView.Add(_cancelButton);

            _saveButton = new UIButton(UIButtonType.System)
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
            };
            _saveButton.SetTitle("Save", UIControlState.Normal);
            containerView.Add(_saveButton);

            _todoTitleView.TopAnchor.ConstraintEqualTo(containerView.TopAnchor).Active = true;
            _todoTitleView.LeftAnchor.ConstraintEqualTo(containerView.LeftAnchor).Active = true;
            _todoTitleView.RightAnchor.ConstraintEqualTo(containerView.RightAnchor).Active = true;

            _cancelButton.TopAnchor.ConstraintEqualTo(_todoTitleView.BottomAnchor).Active = true;
            _cancelButton.LeftAnchor.ConstraintEqualTo(containerView.LeftAnchor).Active = true;
            _cancelButton.BottomAnchor.ConstraintEqualTo(containerView.BottomAnchor).Active = true;

            _saveButton.TopAnchor.ConstraintEqualTo(_todoTitleView.BottomAnchor).Active = true;
            _saveButton.RightAnchor.ConstraintEqualTo(containerView.RightAnchor).Active = true;
            _saveButton.BottomAnchor.ConstraintEqualTo(containerView.BottomAnchor).Active = true;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            _cancelButton.TouchUpInside += HandleCancelTouched;
            _saveButton.TouchUpInside += HandleSaveTouched;
        }

        private async void HandleSaveTouched(object sender, System.EventArgs e)
        {
            await AppDelegate.TodoRepository.AddItem(new TodoItem { Title = _todoTitleView.Text });
            NavigationController.PopViewController(true);
        }

        private void HandleCancelTouched(object sender, System.EventArgs e)
        {
            NavigationController.PopViewController(true);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            _cancelButton.TouchUpInside -= HandleCancelTouched;
            _saveButton.TouchUpInside -= HandleSaveTouched;
        }
    }
}
