using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Reflection;
using System.IO;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArtLookUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PainterArtworksPage : ContentPage
    {
        private ObservableCollection<Painting> _paintings = new ObservableCollection<Painting>();


        public PainterArtworksPage(Painter painter)
        {

            InitializeComponent();

            artworks.ItemsSource = painter.Paintings;

        }

        async void OnPaintingSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (artworks.SelectedItem == null)
               return;
         
            var selectedPainting= e.SelectedItem as Painting;

            artworks.SelectedItem = null;
            
            //if (!typeof(WelcomePage).GetTypeInfo().Assembly.GetManifestResourceNames().Contains(selectedPainting.PaintingImageFile))
            //{
            //    await DisplayAlert("Oops!", "No image of the painting.\nTry to imagine it in your head!", "Close and cry...");
            //    return;
            //}

            var page = new PaintingViewPage(selectedPainting);
           
            await Navigation.PushAsync(page);
        }
    }
}