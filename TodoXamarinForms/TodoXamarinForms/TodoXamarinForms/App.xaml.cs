using TodoXamarinForms.Persistence;
using Xamarin.Forms;

namespace TodoXamarinForms
{
    public partial class App : Application
	{
        public static TodoRepository TodoRepository = new TodoRepository();

		public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new TodoListView());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
