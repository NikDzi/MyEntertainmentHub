using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class AddMediaCompanyVM
    {
        public int MediaCompanyID { get; set; }
        public int MediaID { get; set; }
        public string MediaName { get; set; }
        public int CompanyID { get; set; }
        public List<SelectListItem> CompanyStavke { get; set; }
    }
}
