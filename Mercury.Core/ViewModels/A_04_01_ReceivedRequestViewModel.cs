using MvvmCross.Core.ViewModels;
using Mercury.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Mercury.Core.ViewModels
{

    public class A_04_01_ReceivedRequestViewModel : MvxViewModel
    {

        Requests thisReq;

        public void Init(string _reqID)
        {
            Database.GetRequest(Database.primeUser, _reqID);
            thisReq = Database.Users[Database.GetReq_UserIndex].Requests[Database.GetReq_ReqIndex];

            SenderText = thisReq.Receiver.Replace(".", " ");

            AvailabilityText = thisReq.Ans_Status;
            LocationText = thisReq.Ans_Location;
            MessageText = thisReq.Ans_Message;
        }


        public A_04_01_ReceivedRequestViewModel ()
        {


            OkCommand = new MvxCommand(() => ConfirmRequest());
        }

        //-VARS
        public ICommand OkCommand { get; private set; }

        private string _sender;
        public string SenderText
        {
            get { return _sender; }
            set { SetProperty(ref _sender, value); }
        }

        private string _availability;
        public string AvailabilityText
        {
            get { return _availability; }
            set { SetProperty(ref _availability, value); }
        }

        private string _location;
        public string LocationText
        {
            get { return _location; }
            set { SetProperty(ref _location, value); }
        }

        private string _message;
        public string MessageText
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        //-FUNC
        public void ConfirmRequest ()
        {
            //-
            Database.Users[Database.GetReq_UserIndex].Requests.RemoveAt(Database.GetReq_ReqIndex);

            ShowViewModel<A_04_00_RequestHomeViewModel>();
        }

    }
}
