using Mercury.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Core
{
    public class Database
    {
        //-Profile Users
        public static List<string> profiles = new List<string>();
        public static void PopulateProfiles()
        {
            
            profiles.Add("John.User");
            profiles.Add("Jane.User");
  
        }
        //-Populate Check
        public static bool populated = false;
        //-Prime User
        public static string primeUser = "";


        //-------------------------------------------------------------
        //--FUNCTIONS--------------------------------------------------
        public static string Retrieve (string username, string item)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (username == Users[i].Username)
                {
                    if (item == "Name") { return Users[i].Fullname; }
                    if (item == "Status") { return Users[i].Status; }
                    if (item == "Location") { return Users[i].Location; }
                    if (item == "Message") { return Users[i].Message; }
                }
            }
            return "";
        }
        public static void UpdateUser(string username, string parameter, string updateValue)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (username == Users[i].Username)
                {
                    if (parameter == "Status") { Users[i].Status = updateValue; }
                    if (parameter == "Location") { Users[i].Location = updateValue; }
                    if (parameter == "Message") { Users[i].Message = updateValue; }
                }
            }
        }

        public static void MakeRequest(string username, Requests ir)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (username == Users[i].Username)  { Users[i].Requests.Add(ir); }
                if (ir.Sender == Users[i].Username) { Users[i].Requests.Add(ir); }
            }
        }
        public static void UpdateRequest(string userSender, string userRecipient, string _id, string status, string location, string message)
        {
            for (int i = 0; i < Users.Count; i++)
            {
            if(Users[i].Username == userSender)
                {
                for(int j=0; j < Users[i].Requests.Count; j++)
                    {
                    if(Users[i].Requests[j].UniqueID == _id)
                        {
                            //-Update
                            Users[i].Requests[j].RequestState = 2;
                            Users[i].Requests[j].Ans_Status = status;
                            Users[i].Requests[j].Ans_Location = location;
                            Users[i].Requests[j].Ans_Message = message;
                            Users[i].Requests[j].Ans_Date = DateTime.Now.Date.ToString("dd/MM/yyy");
                            Users[i].Requests[j].Ans_Time = DateTime.Now.ToString("h:mm tt");
                            Users[i].Requests[j].ReceiverDetails = Users[i].Requests[j].ReceiverDetails + " - !";
                        }
                    }
                }

                if (Users[i].Username == userRecipient)
                {
                    for (int j = 0; j < Users[i].Requests.Count; j++)
                    {
                        if (Users[i].Requests[j].UniqueID == _id)
                        {
                            //-Update [Remove from Recipient's List]
                            Users[i].Requests.RemoveAt(j);

                        }
                    }
                }
            }

        }

        public static int GetReq_UserIndex=0;
        public static int GetReq_ReqIndex = 0;

        public static void GetRequest(string user, string uniqueID)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Username == user)
                {
                    GetReq_UserIndex = i;//-

                    for (int j = 0; j < Users[i].Requests.Count; j++)
                    {
                        if (Users[i].Requests[j].UniqueID == uniqueID)
                        {
                            //-Update
                            GetReq_ReqIndex = j;//-
                        }
                    }
                }
            }

            }

        //-------------------------------------------------------------
        //--DATA-------------------------------------------------------
        public static List<Locations> _locations = new List<Locations>();
        public static void PopulateLocations ()
        {
            _locations.Add(new Locations("Office Room A"));
            _locations.Add(new Locations("Office Room B"));
            _locations.Add(new Locations("Office Room C"));
            _locations.Add(new Locations("Office Room D"));
            _locations.Add(new Locations("Office Room E"));
            _locations.Add(new Locations("Office Room F"));
            _locations.Add(new Locations("Meeting Room A"));
            _locations.Add(new Locations("Meeting Room B"));
            _locations.Add(new Locations("Meeting Room C"));
            _locations.Add(new Locations("Meeting Room D"));
            _locations.Add(new Locations("Cubicle 01"));
            _locations.Add(new Locations("Cubicle 02"));
            _locations.Add(new Locations("Cubicle 03"));
            _locations.Add(new Locations("Cubicle 04"));
            _locations.Add(new Locations("Cubicle 05"));
            _locations.Add(new Locations("Cubicle 06"));
            _locations.Add(new Locations("Restroom A"));
            _locations.Add(new Locations("Restroom B"));
            _locations.Add(new Locations("Kitchen"));
            _locations.Add(new Locations("Lobby"));
            _locations.Add(new Locations("Reception"));


        }

        public static List<Users> Users = new List<Users>();
        public static void PopulateUsers()
        {
            Users.Add(new Users("Manda Servin", "577"));
            Users.Add(new Users("Eldridge Mesa", "502"));
            Users.Add(new Users("Laurinda Brumsey", "265"));
            Users.Add(new Users("Adriane Prosper", "550"));
            Users.Add(new Users("Crissy Sevilla", "679"));
            Users.Add(new Users("Aron Augsburger", "115"));
            Users.Add(new Users("Liberty Holzer", "710"));
            Users.Add(new Users("Christi Quillen", "857"));
            Users.Add(new Users("Kam Disher", "360"));
            Users.Add(new Users("Delmer Kampa", "412"));
            Users.Add(new Users("Elijah Permenter", "677"));
            Users.Add(new Users("Darius Hanus", "491"));
            Users.Add(new Users("Venus Brockway", "720"));
            Users.Add(new Users("Ariane Bissonnette", "401"));
            Users.Add(new Users("Sherrill Kulikowski", "371"));
            Users.Add(new Users("Modesto Mera", "856"));
            Users.Add(new Users("Cicely Pooler", "255"));
            Users.Add(new Users("Margarita Maness", "732"));
            Users.Add(new Users("Ivan Webre", "736"));
            Users.Add(new Users("Maybelle Kammer", "984"));
        }

    }


}
