using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class LocationVM
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public int MediaLocationID { get; set; }
        public ImageVM Thumbnail { get; set; }
    }
}
