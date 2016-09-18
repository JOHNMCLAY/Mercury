using Android.App;
using Android.OS;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace Mercury.Droid.Views
{
    [Activity(
    Label = "A_03_00_HomeViewModel"
    , Theme = "@style/Theme.App"
    , ScreenOrientation = ScreenOrientation.Portrait)]
    //
    public class A_03_00_HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.L_03_00_HomeView);
        }
    }
}