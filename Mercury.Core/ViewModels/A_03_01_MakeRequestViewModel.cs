using MvvmCross.Core.ViewModels;
using Mercury.Core;
using Mercury.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;
using System;
using System.Threading.Tasks;

namespace Mercury.Core.ViewModels
{
    class A_03_01_MakeRequestViewModel : MvxViewModel
    {
        //-INIT
        private string _ps;
        public string PreviousScreen
        {
            get { return _ps; }
            set { SetProperty(ref _ps, value); }
        }

        public void Init(string _previousWindow)
        {
            PreviousScreen = _previousWindow;
        }


        //-MAIN
        public A_03_01_MakeRequestViewModel()
        {
            //-Setup User List
            UserProfiles = new ObservableCollection<Users>() {};
            for (int i = 0; i < Database.Users.Count; i++)
            {
                UserProfiles.Add(Database.Users[i]);
            }

            RequestNotify = "Tap to Send Request...";

            //-Functionality
            SelectUserCommand = new MvxCommand<Users>(item => CreateRequest(item));

            BackCommand = new MvxCommand(() => GoBack());

        }


        //-VARS
        public ICommand SelectUserCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        private ObservableCollection<Users> _users;
        public ObservableCollection<Users> UserProfiles
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }
        //-
        private string _name;
        public string Fullname
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _back;
        public string Back
        {
            get { return _back; }
            set { SetProperty(ref _back, value); }
        }

        private string _rn;
        public string RequestNotify
        {
            get { return _rn; }
            set { SetProperty(ref _rn, value); }
        }

        //-FUNCTIONS
        public void CreateRequest (Users _user)
        {
            string date = DateTime.Now.Date.ToString("dd/MM/yyy");
            string time = DateTime.Now.ToString("h:mm tt");
            string uniqueID = Guid.NewGuid().ToString();
            Requests _tempIR = new Requests(Database.primeUser, _user.Username, date, time, uniqueID);

            Debug.WriteLine("Request: " + _tempIR);
            Database.MakeRequest(_user.Username, _tempIR);

            //**ADD A PUSH NOTIFICATION TO SENDEE!
            //**ADD NOTIFICATION TO PRIME USER
            RequestNotify = "Request Sent!";
            var result = ResultNotify();
            //**
        }

        public void GoBack ()
        {
            if(PreviousScreen == "HOME") { ShowViewModel<A_03_00_HomeViewModel>(); }

            if(PreviousScreen == "REQUESTS") { ShowViewModel<A_04_00_RequestHomeViewModel>(); }

        }

        public async Task ResultNotify()
        {
            await Task.Delay(1000);
            RequestNotify = "Tap to Send Request...";
        }


    }
}
