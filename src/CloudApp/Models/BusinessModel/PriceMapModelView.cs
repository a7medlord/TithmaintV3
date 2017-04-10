using System;

namespace CloudApp.Models.BusinessModel
{
    public class PriceMapModelView
    {
        public long Id { get; set; }

        public string TypeOfAqar { get; set; }
        public string Classfications { get; set; }

        public string Area { get; set; }

        public string PriceOfMeter { get; set; }

        public string SoqfPrice { get; set; }

        public int Type { get; set; }   

        public string Longtut { get; set; }

        public string Latutue { get; set; }

    }
}
