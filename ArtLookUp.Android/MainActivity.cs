﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms;

namespace ArtLookUp.Droid
{
    [Activity(Label = "ArtLookUp", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation =ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            MessagingCenter.Subscribe<PaintingViewPage>(this, "unlockLandscape", sender =>
            {
                RequestedOrientation = ScreenOrientation.Unspecified;
            });

            MessagingCenter.Subscribe<PaintingViewPage>(this, "lockLandscape", sender =>
            {
                RequestedOrientation = ScreenOrientation.Portrait;
            });

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

        }
    }
}