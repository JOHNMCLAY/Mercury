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

    public class A_01_00_ProfileViewModel : MvxViewModel
    {
        //-User Profiles
        //Database db;// = new Database();
        private ObservableCollection<Users> _userProfiles;
        public ObservableCollection<Users> UserProfiles
        {
            get { return _userProfiles; }
            set { SetProperty(ref _userProfiles, value); }   
        }
        //-
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        //-----------------------------------------------------
        public ICommand SelectItemCommand { get; private set; }
        public ICommand RegistrationCommand { get; private set; }

        public A_01_00_ProfileViewModel()
        {
            //-Setup User Profiles
            if (Database.populated == false)
            {
                Database.PopulateProfiles();
                UserProfiles = new ObservableCollection<Users>() { };
                for (int i = 0; i < Database.profiles.Count; i++)
                {
                    UserProfiles.Add(new Users(Database.profiles[i]));
                    Database.Users.Add(UserProfiles[i]);
                }

                Database.populated = true;

                //-Setup Database
                Database.PopulateLocations();
                Database.PopulateUsers();
            }
            else
            {
                UserProfiles = new ObservableCollection<Users>() { };
                for (int i = 0; i < Database.Users.Count; i++)
                {
                    if (Database.Users[i].IsUser == 1)
                    {
                        UserProfiles.Add(Database.Users[i]);
                    }
                }
            }

            //-Select User
            SelectItemCommand = new MvxCommand<Users>(item => ShowViewModel<A_02_LogInViewModel>(new { _fullname = item.Fullname, _username = item.Username }));
            //-Register a New User
            RegistrationCommand = new MvxCommand(() => ShowViewModel<A_01_01_RegistrationViewModel>());


        }


    }
}
