using System;
using System.IO;
using TodoXamarinForms.Droid;
using TodoXamarinForms.Persistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace TodoXamarinForms.Droid
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}