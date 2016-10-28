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

    public class A_01_01_RegistrationViewModel : MvxViewModel
    {

        //-
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _pin;
        public string PIN
        {
            get { return _pin; }
            set { SetProperty(ref _pin, value); }
        }

        private string _TTpin;
        public string TooltipPIN
        {
            get { return _TTpin; }
            set { SetProperty(ref _TTpin, value); }
        }

        private string _TTusername;
        public string TooltipUN
        {
            get { return _TTusername; }
            set { SetProperty(ref _TTusername, value); }
        }

        //-----------------------------------------------------
        public ICommand OkCommand { get; private set; }
        public ICommand BackCommand { get; private set; }

        public A_01_01_RegistrationViewModel()
        {
            Username = "User.Name";
            PIN = "123";
            //-Select User
            //SelectItemCommand = new MvxCommand<Users>(item => ShowViewModel<A_02_LogInViewModel>( new { _fullname = item.Fullname, _username = item.Username } ));


            //-Button Functionality
            BackCommand = new MvxCommand(() => ShowViewModel<A_01_00_ProfileViewModel>());
            OkCommand = new MvxCommand(() => CreateUser());
        }

        //-
        public void CreateUser()
        {
            bool pinPass = false;
            bool unPass = false;

            //-Check PIN validity
            if (PIN.Length < 3)
            {
                TooltipPIN = " - [ Minimum 3 digits ]";
                pinPass = false;
            }
            else
            {
                PIN = PIN.Substring(0, 3);
                pinPass = true;
                TooltipPIN = "";
            }

            //Check Username Validity
            if(Username.IndexOf('.')!=-1
            && Username.IndexOf('.') == Username.LastIndexOf('.')
            && Username.IndexOf(" ")==-1)
            {
                TooltipUN = "";
                unPass = true;
            }
            else
            {
                TooltipUN = " - [ Name.Name ]";
                unPass = false;
            }

            //-If Both are Valid
            if (unPass == true && pinPass == true)
            {
                Database.Users.Add(new Users(Username, PIN, 1));
                ShowViewModel<A_01_00_ProfileViewModel>();
            }
        }


    }
}
