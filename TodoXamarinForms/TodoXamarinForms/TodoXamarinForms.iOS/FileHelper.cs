using System;
using System.IO;
using TodoXamarinForms.iOS;
using TodoXamarinForms.Persistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace TodoXamarinForms.iOS
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
