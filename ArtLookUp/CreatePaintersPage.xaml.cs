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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArtLookUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreatePaintersPage : ContentPage
	{
        private ObservableCollection<Painter> _painters = new ObservableCollection<Painter>();


        public CreatePaintersPage(Period period)
        {
            InitializeComponent();

            foreach (var collection in period.Collections)
            {

                var painterDataName = collection.File;

                var assembly = typeof(WelcomePage).GetTypeInfo().Assembly;
                string jsonFileName = "ArtLookUp.Droid.Painters_Data." + painterDataName;

                var a = assembly.GetManifestResourceNames();

                Stream stream = assembly.GetManifestResourceStream(jsonFileName);
                DataPainter dataPainter;

                using (var reader = new System.IO.StreamReader(stream))
                {
                    var jsonString = reader.ReadToEnd();

                    //Converting JSON Array Objects into generic list    
                    dataPainter = JsonConvert.DeserializeObject<DataPainter>(jsonString);

                    if (dataPainter == null) throw new Exception("Error! JSON file of " + collection.Name + " does not contain any info about the painter!");
                    if (dataPainter.artworks == null) throw new Exception("Error! JSON file of " + collection.Name + " does not contain any artworks!");


                }


                List<Painting> painterArtworks = new List<Painting>();
                foreach (var painting in dataPainter.artworks)
                {
                    painterArtworks.Add(
                        new Painting
                        {
                            Name = painting.name,
                            Year = painting.year,
                            PaintingImageFile = painting.picture
                        }
                        
                    );
                }

                _painters.Add(
                    new Painter {
                        Name = dataPainter.name,
                        Years = dataPainter.years,
                        Location = dataPainter.location,
                        ShortInformation = dataPainter.shortinfolink,
                        BiographyLink = dataPainter.biolink,
                        PortraitImagePath = dataPainter.image,
                        Paintings = painterArtworks

                    }
                );

            }
 
            painters.ItemsSource = _painters;
        }


        async void OnPainterSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // We need to check if SelectedItem is null because further below 
            // we de-select the selected item. This will raise another ItemSelected
            // event, so this method will be called straight away. If we don't
            // check for null here, we'll get a NullReferenceException.
            if (painters.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as Painter;

            // We de-select the selected item, so when we come back to the Contacts
            // page we can tap it again and navigate to ContactDetail. 
            painters.SelectedItem = null;

            var page = new PainterDetailPage(selectedContact);
            page.ContactUpdated += (source, painter) =>
            {
                // When the target page raises ContactUpdated event, we get 
                // notified and update properties of the selected contact. 
                // Here we are dealing with a small class with only a few 
                // properties. If working with a larger class, you may want 
                // to look at AutoMapper, which is a convention-based mapping
                // tool. 
                selectedContact.Years = painter.Years;
                selectedContact.Name = painter.Name;
            };

            await Navigation.PushAsync(page);
        }

    }
}