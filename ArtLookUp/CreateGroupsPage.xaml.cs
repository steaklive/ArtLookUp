using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ArtLookUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateGroupsPage : ContentPage
	{
        private ObservableCollection<Period> _categories = new ObservableCollection<Period>();

		public CreateGroupsPage (Dictionary<string, List<DataPeriodCollection>> periods)
		{
			InitializeComponent ();

            //JObject jObject = JObject.Parse();


            foreach (var period in periods)
            {
                List<Collection> collections = new List<Collection>();

                foreach (var collection in period.Value)
                {
                    collections.Add(
                        new Collection
                        {
                            Name = collection.name,
                            File = collection.file

                        });
                }

                _categories.Add
                (
                    new Period
                    {
                        Name = period.Key,
                        Collections = collections
                    }
                );
            }


            categories.ItemsSource = _categories;
        }

 
        async void OnCategorySelected(object sender, SelectedItemChangedEventArgs e)
        {
            // We need to check if SelectedItem is null because further below 
            // we de-select the selected item. This will raise another ItemSelected
            // event, so this method will be called straight away. If we don't
            // check for null here, we'll get a NullReferenceException.
            if (categories.SelectedItem == null)
                return;

            var selectedPeriod = e.SelectedItem as Period;

            // We de-select the selected item, so when we come back to the Contacts
            // page we can tap it again and navigate to ContactDetail. 
            categories.SelectedItem = null;

            var page = new CreatePaintersPage(selectedPeriod);

           //page.ContactUpdated += (source, category) =>
           //{
           //    // When the target page raises ContactUpdated event, we get 
           //    // notified and update properties of the selected contact. 
           //    // Here we are dealing with a small class with only a few 
           //    // properties. If working with a larger class, you may want 
           //    // to look at AutoMapper, which is a convention-based mapping
           //    // tool. 
           //    selectedContact.Id = category.Id;
           //    selectedContact.Name = category.Name;
           //};

            await Navigation.PushAsync(page);
        }

       

        async void OnDeleteCategory(object sender, System.EventArgs e)
        {
            var category = (sender as MenuItem).CommandParameter as Period;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {category.Name}?", "Yes", "No"))
                _categories.Remove(category);
        }
    }
}