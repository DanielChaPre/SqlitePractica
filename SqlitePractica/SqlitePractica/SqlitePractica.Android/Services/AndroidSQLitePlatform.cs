using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System.IO;
using PracticaSQLite.Droid.Services;
using PracticaSQLite.Services;
using SQLite;
[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLitePlatform))]

namespace PracticaSQLite.Droid.Services
{
    public class AndroidSQLitePlatform : ISQLitePlatform
    {
        public SQLiteConnection GetConnection()
        {
            var dbase = "prueba";
            var dbpath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(dbpath, dbase);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}