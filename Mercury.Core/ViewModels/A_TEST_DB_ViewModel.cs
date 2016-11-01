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

    public class A_TEST_DB_ViewModel : MvxViewModel
    {
        //-User Profiles
        //Database db;// = new Database();
        //private ObservableCollection<Users> _userProfiles;
        //public ObservableCollection<Users> UserProfiles
        //{
        //    get { return _userProfiles; }
        //    set { SetProperty(ref _userProfiles, value); }
        //}
        //-

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _rc;
        public string RecallInfo
        {
            get { return _rc; }
            set { SetProperty(ref _rc, value); }
        }

        //-----------------------------------------------------
        public ICommand SubmitCommand { get; private set; }
        public ICommand RecallCommand { get; private set; }

        //-DB Connection
        private readonly SQL_UserDatabase_I User_Database;

        public A_TEST_DB_ViewModel(SQL_UserDatabase_I _userDB)
        {

            User_Database = _userDB;

            RecallInfo = "Null";



            //-Select User
            SubmitCommand = new MvxCommand(() => Submit() );
            //-Register a New User
            RecallCommand = new MvxCommand(() => Recall() );


        }

        public void Submit ()
        {
            User_Database.InsertUser();

        }

        public void Recall()
        {
            RecallInfo = "Recall";

        

        }

    }
}
