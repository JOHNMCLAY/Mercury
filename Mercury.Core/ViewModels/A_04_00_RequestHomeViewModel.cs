using MvvmCross.Core.ViewModels;
using Mercury.Core.Models;
using System;
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
    public class A_04_00_RequestHomeViewModel : MvxViewModel
    {


        public A_04_00_RequestHomeViewModel()
        {
            //-Setup
            SentRequests = new ObservableCollection<Requests>() { };
            IncomingRequests = new ObservableCollection<Requests>() { };
            SetupLists();

            SelectIncomingCommand = new MvxCommand<Requests>(item => ShowViewModel<A_04_02_AnswerRequestViewModel>(new { _id = item.UniqueID }));
            SelectSentUserCommand = new MvxCommand<Requests>(item => CheckSentRequest(item));

            NewRequestCommand = new MvxCommand(() => ShowViewModel<A_03_01_MakeRequestViewModel>(new { _previousWindow = "REQUESTS" }));

            BackCommand = new MvxCommand(() => ShowViewModel<A_03_00_HomeViewModel>());
        }


        //-VARS
        public ICommand NewRequestCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        public ICommand SelectSentUserCommand { get; private set; }
        public ICommand SelectIncomingCommand { get; private set; }

        private ObservableCollection<Requests> _incomingRequests;
        public ObservableCollection<Requests> IncomingRequests
        {
            get { return _incomingRequests; }
            set { SetProperty(ref _incomingRequests, value); }
        }

        private ObservableCollection<Requests> _sentRequests;
        public ObservableCollection<Requests> SentRequests
        {
            get { return _sentRequests; }
            set { SetProperty(ref _sentRequests, value); }
        }

        private string _receiver;
        public string ReceiverDetails
        {
            get { return _receiver; }
            set { SetProperty(ref _receiver, value); }
        }

        private string _sender;
        public string SenderDetails
        {
            get { return _sender; }
            set { SetProperty(ref _sender, value); }
        }

        public void SetupLists ()
        {
            for(int i=0; i<Database.Users.Count; i++)
            {
            if(Database.Users[i].Username == Database.primeUser)
                {
                    for (int j=0; j<Database.Users[i].Requests.Count; j++)
                    {
                    //-Sent
                    if(Database.Users[i].Requests[j].Sender == Database.primeUser)
                        {
                            SentRequests.Add(Database.Users[i].Requests[j]);
                        }
                    //-Received
                    if (Database.Users[i].Requests[j].Receiver == Database.primeUser)
                        {
                            IncomingRequests.Add(Database.Users[i].Requests[j]);
                        }
                    }
                }
            }
            



        }

        public void CheckSentRequest(Requests item)
        {
            if (item.RequestState == 1) { }
            if (item.RequestState == 2)
            {
                ShowViewModel<A_04_01_ReceivedRequestViewModel>(new { _reqID = item.UniqueID });
            }


        }
    }
}
