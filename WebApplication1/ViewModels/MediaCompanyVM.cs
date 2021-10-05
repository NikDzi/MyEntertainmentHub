using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class MediaCompanyVM
    {
        public int MediaCompanyID { get; set; }
        public int MediaID { get; set; }
        public string MediaName { get; set; }
        public string MediaType { get; set; }
        public int CompanyID { get; set; }
    }
}
