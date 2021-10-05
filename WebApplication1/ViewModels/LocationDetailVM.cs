using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace WebApplication1.ViewModels
{
    public class LocationDetailVM
    {
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string City { get; set; }
        public string? Description { get; set; }
        public int MediaLocationID { get; set; }
        public List<MediaLocationVM> MediaLocationStavke { get; set; }
        public List<ImageVM> ImageList { get; set; }
        // za google maps
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
