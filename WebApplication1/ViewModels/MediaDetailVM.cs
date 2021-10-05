using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class MediaDetailVM
    {
        public int MediaID { get; set; }
        public string? MediaName { get; set; }
        public string? Description { get; set; }
        public string? ReleaseDate { get; set; }
        public string? EpisodeLength { get; set; }
        public int? EpisodeCount { get; set; }
        public string? Budget { get; set; }
        public string? Earnings { get; set; }
        public string? MediaType { get; set; }
        public string? Country { get; set; }
        public string? Language { get; set; }
        public string? Rating { get; set; }
        public int? CrewID { get; set; }
        public List<CrewPersonVM> CrewStavke { get; set; }
        public int? CastID { get; set; }
        public List<CastPersonVM> CastStavke { get; set; }
        public List<LocationVM> LocationStavke { get; set; }
        public List<CompanyVM> CompanyStavke { get; set; }
        public List<Genre> GenreStavke { get; set; }
        //public List<Soundtracks> Soundtracks { get; set; }
        //public int? SoundtrackID { get; set; }
        public TechnicalSpecifications TechnicalSpecifications { get; set; }
        public int? TechnicalSpecificationsID { get; set; }
        public string? composer { get; set; }
        //new below
        public List<ImageVM> ImageList { get; set; }
        public List<AddCommentVM> Comments { get; set; }
    }
}
