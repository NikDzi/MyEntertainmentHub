using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class AddMediaVM
    {
        public int MediaID { get; set; }
        [Required]
        [DisplayName("Media Name")]
        [StringLength(100)]
        public string MediaName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [DisplayName("Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string EpisodeLength { get; set; }
        public int? EpisodeCount { get; set; }
        [Required]
        [RegularExpression(@"^\$?\-?[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\.[0-9]{2})?$")]
        public string Budget { get; set; }
        [RegularExpression(@"^\$?\-?[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\.[0-9]{2})?$")]
        public string? Earnings { get; set; }
        public List<CheckBoxItem> GenreStavke { get; set; }
        public List<SelectListItem> MediaTypeStavke { get; set; }
        [Required]
        [DisplayName("Media Type")]
        public int MediaTypeID { get; set; }
        public List<SelectListItem> CountryStavke { get; set; }
        public int? CountryID { get; set; }
        public List<SelectListItem> LanguageStavke { get; set; }
        [Required]
        [DisplayName("Language")]
        public int LanguageID { get; set; }
        public List<SelectListItem> RatingStavke { get; set; }
        [Required]
        [DisplayName("Rating")]
        public int RatingID { get; set; }
        public List<int> ListOfCompanies { get; set; }
        public List<SelectListItem> CompanyStavke { get; set; }
        public List<int> ListOfLocations { get; set; }
        public List<SelectListItem> LocationStavke { get; set; }

        //public List<SelectListItem> TechnicalSpecificationsStavke { get; set; }
        //public int? TechnicalSpecificationsID { get; set; }
    }
}
