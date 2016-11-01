using Mercury.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Core
{
    public interface SQL_UserDatabase_I
    {
        IEnumerable<SQL_Users> GetUsers();

        int DeleteUser(object id);

        int InsertUser(SQL_Users user);
    }

}