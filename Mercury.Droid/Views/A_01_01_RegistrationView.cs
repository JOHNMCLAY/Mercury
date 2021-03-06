using Android.App;
using Android.OS;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace Mercury.Droid.Views
{
    [Activity(
    Label = "A_01_01_RegistrationViewModel"
    , Theme = "@style/Theme.App"
    , ScreenOrientation = ScreenOrientation.Portrait)]
    //
    public class A_01_01_RegistrationView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.L_01_01_Registration);
        }
    }
}