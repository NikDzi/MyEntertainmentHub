using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class AddCrewPersonVM
    {
        public int CrewPersonID { get; set; }
        public int MediaID { get; set; }
        public string MediaName { get; set; }
        public int PersonID { get; set; }
        public List<SelectListItem> PersonStavke { get; set; }
        public int OccupationID { get; set; }
        public List<SelectListItem> OccupationStavke { get; set; }
    }
}
