using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1.Model
{
    public class Location
    {
        public int LocationID { get; set; }
        public City City { get; set; }
        [Required]
        public int CityID { get; set; }
        [Required]
        [DisplayName("Location Name")]
        [StringLength(100)]
        public string LocationName { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        //[RegularExpression(@"^(\+|-)?(?:90(?:(?:\,0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\,[0-9]{1,6})?))*")]
        [RegularExpression(@"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))*")]
        public decimal? Latitude { get; set; }
        //[RegularExpression(@"^(\+|-)?(?:180(?:(?:\,0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\,[0-9]{1,6})?))*")]
        [RegularExpression(@"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))*")]
        public decimal? Longitude { get; set; }
    }
}
