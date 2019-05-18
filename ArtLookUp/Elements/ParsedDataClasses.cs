using System;
using System.Collections.Generic;
using System.Text;

namespace ArtLookUp
{
    class ParsedDataClasses
    {
    }

    public class DataPainting
    {
        public string name { get; set; }
        public string year { get; set; }
        public string picture { get; set; }
    }

    public class DataPainter
    {
        public string name { get; set; }
        public string years { get; set; }
        public string location { get; set; }
        public string shortinfolink { get; set; }
        public string biolink { get; set; }
        public string image { get; set; }
        public List<DataPainting> artworks { get; set; }
    }

    public class DataPeriodCollection
    {
        public string name { get; set; }
        public string file { get; set; }
    }
    
    public class DataPeriod
    {
        public string name { get; set; }

        public List<DataPeriodCollection> collection { get; set; }

    }

    public class DataPeriodList
    {
        public List<DataPeriod> periods { get; set; }
    }
}
