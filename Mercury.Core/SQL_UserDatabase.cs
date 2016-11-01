using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SQLite.Net;
using Mercury.Core;
using Mercury.Core.Models;
using MvvmCross.Platform;
using System.Threading.Tasks;

namespace Mercury.Core
{
    public class SQL_UserDatabase : SQL_UserDatabase_I
    {

            private SQLiteConnection database;

            public SQL_UserDatabase()
            {
                var sqlite = Mvx.Resolve<SQLite_I>();
                database = sqlite.GetConnection();
                database.CreateTable<SQL_Users>();
            }

            public IEnumerable<SQL_Users> GetUsers()
            {
                return database.Table<SQL_Users>().ToList();
            }

            public int DeleteUser(object id)
            {
                return database.Delete<SQL_Users>(Convert.ToInt16(id));
            }

            public int InsertUser(SQL_Users user)
            {
                var num = database.Insert(user);
                database.Commit();
                return num;
            }



        }





}
