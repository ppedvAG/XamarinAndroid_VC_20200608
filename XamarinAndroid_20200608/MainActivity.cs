using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Content;

namespace XamarinAndroid_20200608
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public EditText Etxt_Eingabe { get; set; }
        public Button Btn_KlickMich { get; set; }
        public Button Btn_Impliziet { get; set; }
        public Button Btn_Expliziet { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Etxt_Eingabe = FindViewById<Android.Widget.EditText>(Resource.Id.main_etxt_Eingabe);
            Btn_KlickMich = FindViewById<Button>(Resource.Id.main_btn_KlickMich);

            Btn_KlickMich.Click += (s, e) => Toast.MakeText(this, $"Deine gewählte Zahl ist {Etxt_Eingabe.Text}.", ToastLength.Short).Show();
            //Btn_KlickMich.Click += ButtonClickEvent;

            //Implizieter Intent
            Btn_Impliziet = FindViewById<Button>(Resource.Id.main_btn_ImplIntent);
            Intent implIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse("http://www.google.de"));
            Btn_Impliziet.Click += (s, e) => StartActivity(implIntent);

            //Explizieter Intent
            Btn_Expliziet = FindViewById<Button>(Resource.Id.main_btn_ExplIntent);
            Intent explIntent = new Intent(this, typeof(ShowPictureActivity));
            Btn_Expliziet.Click += (s, e) => StartActivity(explIntent); 
        }

        private void ButtonClickEvent(object s, EventArgs e)
        {
            Toast.MakeText(this, $"Deine gewählte Zahl ist {Etxt_Eingabe.Text}.", ToastLength.Short).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}