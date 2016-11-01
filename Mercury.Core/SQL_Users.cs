using System;
using SQLite.Net.Attributes;

namespace Mercury.Core
{
    public class SQL_Users
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Username { get; set; }
        public string PIN { get; set; }
        //public string Fullname { get; set; }
        //public string Status { get; set; }
        //public string Location { get; set; }
        //public string Message { get; set; }
        //public int IsUser { get; set; }

        //public string Requests { get; set; }

        //-Constructor
        public SQL_Users()
        {

        }

    }
}
