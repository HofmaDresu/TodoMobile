using System;
using System.IO;
using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;
using TodoXamarinNative.Core;

namespace TodoXamarinNative.Android
{
	//You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public static TodoRepository TodoRepository;

        public MainApplication(IntPtr handle, JniHandleOwnership transer)
          :base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            //A great place to initialize Xamarin.Insights and Dependency Services!

            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var repositoryFilePath = Path.Combine(path, "TodoRepository.db3");
            TodoRepository = new TodoRepository(repositoryFilePath);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {
        }

        public void OnActivityPaused(Activity activity)
        {
        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {
        }
    }
}