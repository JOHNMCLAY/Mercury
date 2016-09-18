using MvvmCross.Core.ViewModels;
using Mercury.Core.Models;
using System.Diagnostics;
using System;
using System.IO;
using System.Windows.Input;

namespace Mercury.Core.ViewModels
{
    public class A_02_LogInViewModel : MvxViewModel
    {
        //-Get Selected User
        public void Init(string _fullname, string _username)
        {
            Fullname = _fullname;
            Database.primeUser = _username;
            PIN = "";
        }

        private string _fullname;
        public string Fullname
        {
            get { return _fullname; }
            set { SetProperty(ref _fullname, value); }
            //set{ RaisePropertyChanged(() => Fullname); }
        }


        public A_02_LogInViewModel()
        {
            Button1 = new MvxCommand(() => EnterPIN("1") );
            Button2 = new MvxCommand(() => EnterPIN("2") );
            Button3 = new MvxCommand(() => EnterPIN("3") );
            Button4 = new MvxCommand(() => EnterPIN("4") );
            Button5 = new MvxCommand(() => EnterPIN("5") );
            Button6 = new MvxCommand(() => EnterPIN("6") );
            Button7 = new MvxCommand(() => EnterPIN("7") );
            Button8 = new MvxCommand(() => EnterPIN("8") );
            Button9 = new MvxCommand(() => EnterPIN("9") );

            ButtonBack = new MvxCommand(() => EnterPIN("<") );

            //-Check PIN
            //if(PIN.Length==3) { Fullname = "YESSS"; }
        }


        //-KEYPAD
        public ICommand Button1 { get; private set; }
        public ICommand Button2 { get; private set; }
        public ICommand Button3 { get; private set; }
        public ICommand Button4 { get; private set; }
        public ICommand Button5 { get; private set; }
        public ICommand Button6 { get; private set; }
        public ICommand Button7 { get; private set; }
        public ICommand Button8 { get; private set; }
        public ICommand Button9 { get; private set; }
        public ICommand ButtonBack { get; private set; }

        private string _PIN;
        public string PIN
        {
            get { return _PIN; }
            set { SetProperty(ref _PIN, value); }
            //set{ RaisePropertyChanged(() => Fullname); }
        }

        private void EnterPIN(string input)
        {
            if(input != "<") { PIN += input; }
            if(input == "<") { PIN = PIN.Remove(PIN.Length - 1); }
            //
            if (PIN.Length == 3)
            {
                if(PIN=="123") { ShowViewModel<A_03_00_HomeViewModel>(); }
                else { PIN = ""; }
            }
        }


    }
}
