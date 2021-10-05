using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class PersonOccupationVM
    {
        public int PersonOccupationID { get; set; }
        public int PersonID { get; set; }
        public int OccupationID { get; set; }
        public string OccupationName { get; set; }
    }
}

