using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1.Model
{
    public class Media
    {
        public int MediaID { get; set; }
        [Required]
        [DisplayName("Media Name")]
        [StringLength(100)]
        public string MediaName { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string EpisodeLength { get; set; } // pogledati regex za ovo
        public int? EpisodeCount { get; set; }
        [Required]
        [RegularExpression(@"^\$?\-?[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\.[0-9]{2})?$")]
        public string Budget { get; set; }
        [RegularExpression(@"^\$?\-?[+-]?[0-9]{1,3}(?:,?[0-9]{3})*(?:\.[0-9]{2})?$")]
        public string? Earnings { get; set; }
        public MediaType MediaType { get; set; }
        [Required]
        [DisplayName("Media Type")]
        public int MediaTypeID { get; set; }
        public Country Country { get; set; }
        public int? CountryID { get; set; }
        public Language Language { get; set; }
        [Required]
        [DisplayName("Language")]
        public int LanguageID { get; set; }
        public Rating Rating { get; set; }
        [Required]
        [DisplayName("Rating")]
        public int RatingID { get; set; }
        public Cast Cast { get; set; }
        public Crew Crew { get; set; }
        public TechnicalSpecifications TechnicalSpecifications { get; set; }
        public int? TechnicalSpecificationsID { get; set; }
    }
}
