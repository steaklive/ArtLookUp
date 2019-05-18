using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ArtLookUp
{
    public class Painter
    {
        public string Name { get; set; }
        public string Years { get; set; }
        public string Location { get; set; }
        public string ShortInformationLink { get; set; }
        public string BiographyLink { get; set; }
        public string PortraitImagePath { get; set; }
        public List<Painting> Paintings { get; set; } 

    }
}
