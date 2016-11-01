
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
using Mercury.Core;
using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;

namespace Mercury.Droid.Database
{
    class SQLiteDroid : SQLite_I
    {

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Users.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            
            var connection = new SQLiteConnection(new SQLitePlatformAndroid(), path);
            
            return connection;
        }

    }
}