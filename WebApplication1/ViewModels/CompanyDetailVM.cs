using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassLibrary1.Model;

namespace WebApplication1.ViewModels
{
    public class CompanyDetailVM
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public int MediaCompanyID { get; set; }
        public List<MediaCompanyVM> MediaCompanyStavke { get; set; }
        //new below
        public List<ImageVM> ImageList { get; set; }
    }
}
