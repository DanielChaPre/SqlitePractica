using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using PracticaSQLite.iOS.Services;
using PracticaSQLite.Services;
using SQLite;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(iOSSQLitePlatform))]
namespace PracticaSQLite.iOS.Services
{
    public class iOSSQLitePlatform : ISQLitePlatform
    {
        private string GetPath()
        {
            var dbName = "Practica.db3";
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return path;
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(GetPath());
        }

        public SQLiteAsyncConnection GetConnectionAsync()
        {
            return new SQLiteAsyncConnection(GetPath());
        }
    }
}