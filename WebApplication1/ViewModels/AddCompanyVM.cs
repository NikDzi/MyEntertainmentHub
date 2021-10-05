using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels
{
    public class AddCompanyVM
    {
        public int CompanyID { get; set; }
        [Required]
        [DisplayName("Company Name")]
        [StringLength(100)]
        public string CompanyName { get; set; }
        [Required]
        [DisplayName("Company Type")]
        public int CompanyTypeID { get; set; }
        public List<SelectListItem> CompanyTypeStavke { get; set; }
        public int? CityID { get; set; }
        public List<SelectListItem> CityStavke { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
