using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class MediaLocationVM
    {
        public int MediaLocationID { get; set; }
        public int MediaID { get; set; }
        public string MediaName { get; set; }
        public string MediaType { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string LocationCity { get; set; }
    }
}
