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
	public partial class CategoryDetailPage : ContentPage
	{

        public CategoryDetailPage(Period category)
        {
            // Note the use of nameof() operator in C# 6. 
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            InitializeComponent();

            // We do not use the given contact as the BindingContext. 
            // The reason for this is that if the user make changes and
            // clicks the back button (instead of Save), the changes 
            // should be reverted. So, we create a separate Contact object
            // based on the given Contact and use that temporarily on this
            // page. When Save is clicked, we raise an event and notify 
            // others (in this case ContactsPage) that a contact is added or 
            // updated.
            BindingContext = new Period
            {
               Name = category.Name
            };
        }

    }
}