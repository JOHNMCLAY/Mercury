using System;
using SQLite.Net.Attributes;

namespace Mercury.Core
{
    public class SQL_Requests
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

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


        public SQL_Requests()
        {
        }
    }
}
