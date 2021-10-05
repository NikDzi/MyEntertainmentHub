using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;
namespace WebApplication1.ViewModels
{
    public class MediaVM
    {
        public int MediaID { get; set; }
        public string MediaName { get; set; }
        public ImageVM Thumbnail { get; set; }
        public List<WatchListMedia> WatchLists { get; set; }

    }
}
