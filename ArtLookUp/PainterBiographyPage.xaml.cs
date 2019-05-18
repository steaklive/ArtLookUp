using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArtLookUp
{

    public interface IWebViewBaseUrl { string GetBaseUrl(); }

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PainterBiographyPage : ContentPage
	{

        public  string GetFileContent(string fileName)
        {
            string content;
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream(fileName);
            if (stream == null) return null;
            using (var reader = new StreamReader(stream)) content = reader.ReadToEnd();

            return content;
        }

        public PainterBiographyPage (Painter painter)
		{
			InitializeComponent ();
            webviewBio.Source = "file:///android_asset/biographies/" + painter.BiographyLink;


        }

    }
}