using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace ArtLookUp
{
    public class Collection
    {
        public string Name { get; set; }
        public string File { get; set; }


    }
    public class Period
    {
        public string Name { get; set; }
        public List<Collection> Collections { get; set; }

    }

    public class PeriodList
    {
        public List<Period> periods;
    }
}
