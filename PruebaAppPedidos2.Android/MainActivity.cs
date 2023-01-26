using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Acr.UserDialogs;
using Android.Content;
using System.Security;
using Java.Security;
using static Android.Provider.Settings;
using static PruebaAppPedidos2.Droid.MainActivity;

[assembly: Xamarin.Forms.Dependency(typeof(GetInfoImplement))]
namespace PruebaAppPedidos2.Droid
{
    [Activity(Label = "PruebaAppPedidos2", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static ContentResolver myContentResolver;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            myContentResolver = this.ContentResolver;
            UserDialogs.Init(this);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        
        public class GetInfoImplement : IDevice
        {
            string IDevice.DeviceID()
            {
                var context = Android.App.Application.Context;
                string id = Android.Provider.Settings.Secure.GetString(context.ContentResolver, Secure.AndroidId);

                return id;
            }
        }
    }
}