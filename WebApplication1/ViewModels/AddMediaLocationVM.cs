using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class AddMediaLocationVM
    {
        public int MediaLocationID { get; set; }
        public int MediaID { get; set; }
        public string MediaName { get; set; }
        public int LocationID { get; set; }
        public List<SelectListItem> LocationStavke { get; set; }
    }
}
