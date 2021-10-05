using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class Image
    {
        public int ImageID { get; set; }
        public string ImageCaption { get; set; }
        public string ImageDescription { get; set; }
        public string ImageUniqueFilename { get; set; }
        public bool Thumbnail { get; set; }
        public int? MediaID { get; set; }
        public Media Media { get; set; }
        public int? PersonID { get; set; }
        public Person Person { get; set; }
        public int? LocationID { get; set; }
        public Location Location { get; set; }
        public int? CompanyID { get; set; }
        public Company Company { get; set; }
        public int? CharacterID { get; set; }
        public Character Character { get; set; }
        public string? UserID { get; set; }
        public AppUser User { get; set; }
    }
}
