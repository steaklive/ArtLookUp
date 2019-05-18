using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArtLookUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
        Dictionary<string, List<DataPeriodCollection>> periodsDict = new Dictionary<string, List<DataPeriodCollection>>();

        public WelcomePage ()
		{
			InitializeComponent ();


            DataPeriodList objectPeriodList = new DataPeriodList();

            var assembly = typeof(WelcomePage).GetTypeInfo().Assembly;
            //Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");

            string jsonFileName = "ArtLookUp.Droid.Resources." + "DataCollection.json";

            Stream stream = assembly.GetManifestResourceStream(jsonFileName);

            using (var reader = new System.IO.StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                //Converting JSON Array Objects into generic list    
                objectPeriodList = JsonConvert.DeserializeObject<DataPeriodList>(jsonString);

                if (objectPeriodList == null) throw new Exception("Error! JSON file does not contain a list of periods!");

                foreach (var period in objectPeriodList.periods)
                {
                    periodsDict.Add(period.name, period.collection);
                }


                //JObject o = JObject.Parse(jsonString);
                //foreach (var element in o)
                //{
                //    var single = element.Value.ToString();
                //    var nodeValues = JsonConvert.DeserializeObject<List<DataPeriod>>(single);
                //}
            }

            //image.Source = ImageSource.FromResource("MyExpenZ.Android.titleimage.jpg");

        }

        async void OnExplorePressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateGroupsPage(periodsDict));
        }

    }
}