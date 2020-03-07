using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace XamarinSplashScreen
{
    [Activity(Label = "SplashScreenActivity", Theme = "@style/Splash", MainLauncher = true)]
    public class SplashScreenActivity : Activity
    {
        static readonly string TAG = "X:" + typeof(SplashScreenActivity).Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            //StartActivity(typeof(MainActivity));
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }

        // Simulates background work that happens behind the splash screen
        async void SimulateStartup()
        {
            Log.Debug(TAG, "Initial processing..");
            await Task.Delay(3000); // Simulate startup work.
            Log.Debug(TAG, "Initialisation completed, starting MainActivity");
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}