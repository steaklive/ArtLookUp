using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArtLookUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PainterDetailPage : ContentPage
	{


        public event EventHandler<Painter> ContactAdded;
        public event EventHandler<Painter> ContactUpdated;

        private Painter _painter;

        public PainterDetailPage(Painter painter)
        {
            // Note the use of nameof() operator in C# 6. 
            if (painter == null)
                throw new ArgumentNullException(nameof(painter));

            _painter = painter;

            InitializeComponent();

            BindingContext = new Painter
            {
                Name = painter.Name,
                Years = painter.Years,
                Location = painter.Location,
                PortraitImagePath = painter.PortraitImagePath,
                ShortInformation = painter.ShortInformation
            };
        }

        async void OpenBiography(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PainterBiographyPage(_painter));
        }

        async void OpenArtworks(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PainterArtworksPage(_painter));
        }

	}
}