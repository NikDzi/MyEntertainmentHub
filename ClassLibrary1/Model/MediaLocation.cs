using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class MediaLocation
    {
        public int MediaLocationID { get; set; }
        public Media Media { get; set; }
        public int MediaID { get; set; }
        public Location Location { get; set; }
        public int LocationID { get; set; }
    }
}
