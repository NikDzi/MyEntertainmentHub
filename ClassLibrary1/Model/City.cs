using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1.Model
{
    public class City
    {
        public int CityID { get; set; }
        [Required]
        [DisplayName("City Name")]
        [StringLength(100)]
        public string CityName { get; set; }
        public Country Country { get; set; }
        [Required]
        public int CountryID { get; set; }
    }
}
