using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class AddCityVM
    {
        public int CityID { get; set; }
        [Required]
        [DisplayName("City Name")]
        [StringLength(100)]
        public string CityName { get; set; }
        [Required]
        public int CountryID { get; set; }
        public List<SelectListItem> CountryStavke { get; set; }
    }
}
