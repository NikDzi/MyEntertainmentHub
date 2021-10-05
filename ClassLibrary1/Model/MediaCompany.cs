using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class MediaCompany
    {
        public int MediaCompanyID { get; set; }
        public Media Media { get; set; }
        public int MediaID { get; set; }
        public Company Company { get; set; }
        public int CompanyID { get; set; }
    }
}
