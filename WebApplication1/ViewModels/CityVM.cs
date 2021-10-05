using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class CityVM
    {
        public int CityID { get; set; }
        [DisplayName("City Name")]
        [StringLength(100)]
        public string CityName { get; set; }
        public string Country { get; set; }
    }
}
