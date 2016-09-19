using MvvmCross.Core.ViewModels;
using Mercury.Core;
using Mercury.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;
using System;

namespace Mercury.Core.ViewModels
{
    class A_03_01_MakeRequestViewModel : MvxViewModel
    {


        public A_03_01_MakeRequestViewModel()
        {
            //-Setup User List
            UserProfiles = new ObservableCollection<Users>() {};
            for (int i = 0; i < Database.Users.Count; i++)
            {
                UserProfiles.Add(Database.Users[i]);
            }

            //-Functionality
            SelectUserCommand = new MvxCommand<Users>(_user => CreateRequest(_user));
        }


        //-VARS
        public ICommand SelectUserCommand { get; private set; }

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

        //-FUNCTIONS
        public void CreateRequest (Users _user)
        {
            string date = DateTime.Now.Date.ToString("dd/MM/yyy");
            string time = DateTime.Now.ToString("h:mm tt");
            IncomingRequests _tempIR = new IncomingRequests(Database.primeUser, _user.Username, date, time);

            Database.AddIncomingRequest(_user.Username, _tempIR);

            //**ADD A SENT REQUEST
            //**ADD A NOTIFICATION!
            //**
        }


    }
}
