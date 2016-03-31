using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Squareup.Picasso;

namespace GoToParks.Droid
{
    [Activity(Label = "Picasso Test", MainLauncher = true)]
    public class PicassoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PicassoLayout);
            ImageView imageView = FindViewById<ImageView>(Resource.Id.picassoImageView);
            Picasso.With(this).Load("http://i.imgur.com/DvpvklR.jpg").Into(imageView);
        }
    }
}