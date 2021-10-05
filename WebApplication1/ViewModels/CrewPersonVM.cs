using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class CrewPersonVM
    {
        public int CrewPersonID { get; set; }
        public int CrewID { get; set; }
        public int MediaID { get; set; }
        public string MediaName { get; set; }
        public int PersonID { get; set; }
        public string? PersonFirstName { get; set; }
        public string? PersonLastName { get; set; }
        public int? OccupationID { get; set; }
        public string OccupationName { get; set; }
    }
}
