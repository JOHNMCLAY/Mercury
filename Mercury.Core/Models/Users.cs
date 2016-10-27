using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        //public List<string> OutgoingRequests { get; set; }
        public List<Requests> Requests { get; set; }

        //-Constructors
        //[For Profiles]
        public Users(string userName)
        {
            Username = userName;
            PIN = "123";
            //
            if (Username == "John.Smith")
            {
                Fullname = "John Smith";
                Status = "STATUS: Available";
                Location = "Office Room A";
                Message = "N/A";
            }
            if (Username == "Jane.Smith")
            {
                Fullname = "Jane Smith";
                Status = "STATUS: Available";
                Location = "Meeting Room B";
                Message = "short meeting";
            }

            Requests = new List<Requests>();
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

            Requests = new List<Requests>();
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

    public class Requests
    {
        public int RequestState { get; set; }
        public string UniqueID { get; set; }
        //
        public string Sender { get; set; }
        public string SenderDetails { get; set; }
        public string Receiver { get; set; }
        public string ReceiverDetails { get; set; }
        public string AskDate { get; set; }
        public string AskTime { get; set; }
        //
        public string Ans_Status { get; set; }
        public string Ans_Location { get; set; }
        public string Ans_Message { get; set; }
        public string Ans_Date { get; set; }
        public string Ans_Time { get; set; }

        //-Constructor
        public Requests(string _sender, string _receiver, string _date, string _time, string _id)
        {
            RequestState = 1; // 1 = Sent | 2 = Answered
            UniqueID = _id;

            Sender = _sender;
            SenderDetails = _sender.Replace(".", " ") + " | " + _time + " - " + _date;
            Receiver = _receiver;
            ReceiverDetails = _receiver.Replace(".", " ") + " | " + _time + " - " + _date; 
            AskDate = _date;
            AskTime = _time;

            Ans_Status = "N/A";
            Ans_Location = "N/A";
            Ans_Message = "N/A";
            Ans_Date = "N/A";
            Ans_Time = "N/A";
        }
        
    }

}
