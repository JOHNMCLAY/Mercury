using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Core.Models
{
    public class Users
    {

        public string Username { get; set; }
        public string PIN { get; set; }
        public string Fullname { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public List<string> SentRequests { get; set; }
        public List<string> IncomingRequests { get; set; }

        //-Constructors
        //[For Profiles]
        public Users(string userName)
        {
            Username = userName;
            PIN = "123";
            //
            if (Username == "John.User")
            {
                Fullname = "John User";
                Status = "STATUS: Available";
                Location = "Office Room A";
                Message = "N/A";
            }
            if (Username == "Jane.User")
            {
                Fullname = "Jane User";
                Status = "STATUS: Available";
                Location = "Meeting Room B";
                Message = "short meeting";
            }
        }
        //[For Other Users]
        public Users(string _fullName, string _pin, string _status, string _loc, string _msg)
        {

        }
    }

    public class Locations
    {
        public string LocationName { get; set; }

        public Locations(string _name)
        {
            LocationName = _name;
        }
    }
}
