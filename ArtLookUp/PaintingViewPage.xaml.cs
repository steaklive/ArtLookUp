﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArtLookUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaintingViewPage : ContentPage
	{
		public PaintingViewPage (Painting painting)
		{
			InitializeComponent ();

            BindingContext = new Painting
            {
                PaintingImageFile = painting.PaintingImageFile
            };

		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "unlockLandscape");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Send(this, "lockLandscape");
        }
    }


}