using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class CompanyVM
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public int MediaCompanyID { get; set; }
        public ImageVM Thumbnail { get; set; }
    }
}
