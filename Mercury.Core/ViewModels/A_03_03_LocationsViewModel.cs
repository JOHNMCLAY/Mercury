using MvvmCross.Core.ViewModels;
using Mercury.Core;
using Mercury.Core.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;

namespace Mercury.Core.ViewModels
{

    public class A_03_03_LocationsViewModel : MvxViewModel
    {




        public A_03_03_LocationsViewModel()
        {
            //-Setup List
            OfficeLocations = new ObservableCollection<Locations>() { };
            for(int i=0; i<Database._locations.Count; i++)
            {
                OfficeLocations.Add(new Locations(Database._locations[i].LocationName));
            }

            //-Select Location
            SelectLocationCommand = new MvxCommand<Locations>(item => SetLocation(item) );
        }
        
        public ICommand SelectLocationCommand { get; private set; }


        private ObservableCollection<Locations> _locations;
        public ObservableCollection<Locations> OfficeLocations
        {
            get { return _locations; }
            set { SetProperty(ref _locations, value); }
        }

        private string _locName;
        public string LocationName
        {
            get { return _locName; }
            set { SetProperty(ref _locName, value); }
        }

        //-FUNCTIONS
        private void SetLocation (Locations l)
        {
            Database.UpdateUser(Database.primeUser, "Location", l.LocationName);
            ShowViewModel<A_03_00_HomeViewModel>();
            Debug.WriteLine("YEEEEEEEEEEEEEEEEE: " + l.LocationName);
        }

    }
}
