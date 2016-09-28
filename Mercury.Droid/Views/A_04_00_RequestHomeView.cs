using Android.App;
using Android.OS;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace Mercury.Droid.Views
{
    [Activity(
    Label = "A_04_00_RequestHomeViewModel"
    , Theme = "@style/Theme.App"
    , ScreenOrientation = ScreenOrientation.Portrait)]
    //
    public class A_04_00_RequestHomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.L_04_00_RequestHomeView);
        }
    }
}