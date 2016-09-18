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
        public Users(string _fullName, string _pin)
        {
            Random r = new Random();

            Fullname = _fullName;
            PIN = _pin;
            Username = _fullName.Replace(" ", ".");
            Location = Database._locations[r.Next(0, Database._locations.Count)].LocationName;

            if(r.Next(1,5)==1) { Status = "STATUS: Unavailable"; }
            else { Status = "STATUS: Available"; }

            if(Status == "STATUS: Unavailable")
            {
                if (r.Next(1, 4) == 1) { Message = "Out to Lunch"; }
                if (r.Next(1, 4) == 2) { Message = "BRB"; }
                if (r.Next(1, 4) == 3) { Message = "Working from Home"; }
            }

            if (Status == "STATUS: Available")
            {
                if (r.Next(1, 4) == 1) { Message = "N/A"; }
                if (r.Next(1, 4) == 2) { Message = "Free until 5pm"; }
                if (r.Next(1, 4) == 3) { Message = "N/A"; }
            }

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
