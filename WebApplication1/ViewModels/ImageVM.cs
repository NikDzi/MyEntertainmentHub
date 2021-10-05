using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class ImageVM
    {
        public int ImageID { get; set; }
        public string ImageCaption { get; set; }
        public string ImageDescription { get; set; }
        public IFormFile MyImage { get; set; }
        public string ImageUniqueFilename { get; set; }
        public bool Thumbnail { get; set; }
        public int? LocationID { get; set; }
        public int? MediaID { get; set; }
        public int? PersonID { get; set; }
        public int? CompanyID { get; set; }
        public int? CharacterID { get; set; }
        public string? UserID { get; set; }

    }
}
