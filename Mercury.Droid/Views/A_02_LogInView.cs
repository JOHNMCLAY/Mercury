using Android.App;
using Android.OS;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace Mercury.Droid.Views
{
    [Activity(
    Label = "A_02_LogInViewModel"
    , Theme = "@style/Theme.App"
    , ScreenOrientation = ScreenOrientation.Portrait)]
    //
    public class A_02_LogInView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.L_02_LogInView);
        }
    }
}