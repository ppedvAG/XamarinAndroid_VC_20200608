using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace XamarinAndroid_20200608
{
    [Activity(Label = "ShowPictureActivity")]
    public class ShowPictureActivity : Activity
    {
        public EditText ETxt_Width { get; set; }
        public EditText ETxt_Height { get; set; }
        public Button Btn_LadeBild { get; set; }
        public ImageView ImgV_RandomPic { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.activity_showpicture);

            ETxt_Height = FindViewById<EditText>(Resource.Id.etx_randomPic_height);
            ETxt_Width = FindViewById<EditText>(Resource.Id.etx_randomPic_width);
            Btn_LadeBild = FindViewById<Button>(Resource.Id.btn_goRandomPic);
            ImgV_RandomPic = FindViewById<ImageView>(Resource.Id.imgRandomPic);

            Btn_LadeBild.Click += async (s, e) =>
            {
                int breite = int.Parse(ETxt_Width.Text);
                int hoehe = int.Parse(ETxt_Height.Text);

                ProgressDialog progressDialog = new ProgressDialog(this);
                progressDialog.SetMessage("Downloading Picture...");

                using (WebClient client = new WebClient())
                {
                    progressDialog.Show();

                    byte[] bild = await client.DownloadDataTaskAsync($"https://placeimg.com/{breite}/{hoehe}/any");
                    Bitmap bitmap = BitmapFactory.DecodeByteArray(bild, 0, bild.Length);

                    ImgV_RandomPic.SetImageBitmap(bitmap);

                    progressDialog.Dismiss();
                }
            };
        }
    }
}