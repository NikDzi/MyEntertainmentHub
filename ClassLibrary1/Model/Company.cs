using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1.Model
{
    public class Company
    {
        public int CompanyID { get; set; }
        [Required]
        [DisplayName("Company Name")]
        [StringLength(100)]
        public string CompanyName { get; set; }
        public CompanyType CompanyType { get; set; }
        [Required]
        public int CompanyTypeID { get; set; }
        public City City { get; set; }
        public int? CityID { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
    }
}
