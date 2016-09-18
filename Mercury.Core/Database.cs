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
        //-Prime User
        public static string primeUser = "";

        //-Other Users
        public static List<Users> Users = new List<Models.Users>();
        public static void InitPopulateUsers()
        {

        }

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
    }


}
