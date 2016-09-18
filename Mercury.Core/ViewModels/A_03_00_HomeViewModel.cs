using MvvmCross.Core.ViewModels;
using Mercury.Core;
using System.Diagnostics;
using System;
using System.IO;
using System.Windows.Input;

namespace Mercury.Core.ViewModels
{
    public class A_03_00_HomeViewModel : MvxViewModel
    {
        
        public A_03_00_HomeViewModel()
        {
            //-SETUP
            Fullname = Database.Retrieve(Database.primeUser, "Name");
            Status = Database.Retrieve(Database.primeUser, "Status");
            Location = Database.Retrieve(Database.primeUser, "Location");

            LocationClick = new MvxCommand(() => ShowViewModel<A_03_03_LocationsViewModel>() );
            StatusClick = new MvxCommand(() => StatusChange() );

            MakeRequest = new MvxCommand(() => ShowViewModel<A_03_01_MakeRequestViewModel>());
        }

        //-NAVIGATION ------------------------------
        public ICommand LocationClick { get; private set; }
        public ICommand StatusClick { get; private set; }

        public ICommand MakeRequest { get; private set; }

        //-INFO ------------------------------------
        // Name
        private string _fullname;
        public string Fullname
        {
            get { return _fullname; }
            set { SetProperty(ref _fullname, value); }
        }
        // Date
        private string _date;
        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }
        // Time
        private string _time;
        public string Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }
        // Location
        private string _loc;
        public string Location
        {
            get { return _loc; }
            set { SetProperty(ref _loc, value); }
        }
        // Status
        private string _status;
        public string Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        //-FUNCTIONS
        private void StatusChange()
        {
            if(Status=="STATUS: Available") { Status = "STATUS: Unavailable"; }
            else { Status = "STATUS: Available";  }

            Database.UpdateUser(Database.primeUser, "Status", Status);
        }
    }
}
