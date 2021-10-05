using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels
{
    public class AddLocationVM
    {
        public int LocationID { get; set; }
        [Required]
        [DisplayName("Location Name")]
        [StringLength(100)]
        public string LocationName { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [Required]
        [DisplayName("City")]
        public int CityID { get; set; }
        public List<SelectListItem> CityStavke { get; set; }

        //za google maps

        //[DisplayFormat(DataFormatString = "{0:0.0000}", ApplyFormatInEditMode = true)] // decimalni brojevi se na edit po defaultu smanje na dvi decimale, ovaj displayformat to mijenja tako da decimalni brojevi ostanu sa 4 decimale
        ////[RegularExpression(@"^(\+|-)?(?:90(?:(?:\,0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\,[0-9]{1,6})?))*")]
        //[RegularExpression(@"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))*")]
        //public decimal? Latitude { get; set; }
        //[DisplayFormat(DataFormatString = "{0:0.0000}", ApplyFormatInEditMode = true)] // decimalni brojevi se na edit po defaultu smanje na dvi decimale, ovaj displayformat to mijenja tako da decimalni brojevi ostanu sa 4 decimale
        ////[RegularExpression(@"^(\+|-)?(?:180(?:(?:\,0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\,[0-9]{1,6})?))*")]
        //[RegularExpression(@"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))*")]
        //public decimal? Longitude { get; set; }

        //alternativni nacin

        [DisplayFormat(DataFormatString = "{0:0.0000}", ApplyFormatInEditMode = true)] // decimalni brojevi se na edit po defaultu smanje na dvi decimale, ovaj displayformat to mijenja tako da decimalni brojevi ostanu sa 4 decimale
        //[RegularExpression(@"^(\+|-)?(?:90(?:(?:\,0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\,[0-9]{1,6})?))*")]
        [RegularExpression(@"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,6})?))*")]
        public string Latitude { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.0000}", ApplyFormatInEditMode = true)] // decimalni brojevi se na edit po defaultu smanje na dvi decimale, ovaj displayformat to mijenja tako da decimalni brojevi ostanu sa 4 decimale
        //[RegularExpression(@"^(\+|-)?(?:180(?:(?:\,0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\,[0-9]{1,6})?))*")]
        [RegularExpression(@"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,6})?))*")]
        public string Longitude { get; set; }
    }
}
