using SQLite.Net;
using System;

namespace Mercury.Core
{
    public interface SQLite_I
    {
        SQLiteConnection GetConnection();
    }

}