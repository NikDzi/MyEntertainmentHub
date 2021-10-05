using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class angularprofileVM
    {
        public int? Broj { get; set; }

        public  List<row> users { get; set; }
        public class row
        {
            public string? userID { get; set; }
            public string username { get; set; }
            public string role { get; set; }
            public int rating { get; set; }
            public int total { get; set; }
        }
        
    }
}
