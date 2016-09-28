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

    public class A_04_02_AnswerRequestViewModel : MvxViewModel
    {
        Requests thisReq;

        public void Init(string _id)
        {
            
            Database.GetRequest(Database.primeUser, _id);
            thisReq = Database.Users[Database.GetReq_UserIndex].Requests[Database.GetReq_ReqIndex];

            Sender = thisReq.Sender.Replace(".", " ");
            
            StatusText = Database.Retrieve(Database.primeUser, "Status");
            LocationText = Database.Retrieve(Database.primeUser, "Location");
            MessageText = Database.Retrieve(Database.primeUser, "Message");
        }


        public A_04_02_AnswerRequestViewModel()
        {
            StatusOkText = "Ok";
            LocationOkText = "Ok";


            //StatusCommand = new MvxCommand(() => );
            StatusOkCommand = new MvxCommand(() => ButtonSwitch("Status"));

            //LocationCommand = new MvxCommand(() => );
            LocationOkCommand = new MvxCommand(() => ButtonSwitch("Location"));

            BackCommand = new MvxCommand(() => ShowViewModel<A_04_00_RequestHomeViewModel>());

            SendCommand = new MvxCommand(() => AnswerRequest());
        }

        //-VARS
        public ICommand StatusCommand { get; private set; }
        public ICommand StatusOkCommand { get; private set; }

        public ICommand LocationCommand { get; private set; }
        public ICommand LocationOkCommand { get; private set; }

        public ICommand SendCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        private string _sender;
        public string Sender
        {
            get { return _sender; }
            set { SetProperty(ref _sender, value); }
        }

        private string _statusText;
        public string StatusText
        {
            get { return _statusText; }
            set { SetProperty(ref _statusText, value); }
        }

        private string _statusOkText;
        public string StatusOkText
        {
            get { return _statusOkText; }
            set { SetProperty(ref _statusOkText, value); }
        }

        private string _locationText;
        public string LocationText
        {
            get { return _locationText; }
            set { SetProperty(ref _locationText, value); }
        }

        private string _locationOkText;
        public string LocationOkText
        {
            get { return _locationOkText; }
            set { SetProperty(ref _locationOkText, value); }
        }

        private string _messageText;
        public string MessageText
        {
            get { return _messageText; }
            set { SetProperty(ref _messageText, value); }
        }

        //-FUNC
        public void ButtonSwitch (string button)
        {
            if(button=="Status")
            {
                if(StatusOkText == "Ok") { StatusOkText = "X"; }
                else { StatusOkText = "Ok"; }
            }
            if(button=="Location")
            {
                if (LocationOkText == "Ok") { LocationOkText = "X"; }
                else { LocationOkText = "Ok"; }
            }
        }

        public void AnswerRequest()
        {
            if(StatusOkText=="X") { StatusText = "N/A"; }
            if(LocationOkText=="X") { LocationText = "N/A"; }

            Database.UpdateRequest(thisReq.Sender, Database.primeUser, thisReq.UniqueID, StatusText, LocationText, MessageText);

            ShowViewModel<A_04_00_RequestHomeViewModel>();
        }

    }
}
