using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class CastPersonVM
    {
        public int CastPersonID { get; set; }
        public int CastID { get; set; }
        public int? MediaID { get; set; }
        public string? MediaName { get; set; }
        public int PersonID { get; set; }
        public string? PersonFirstName { get; set; }
        public string? PersonLastName { get; set; }
        public int? CharacterID { get; set; }
        public string? CharacterFirstName { get; set; }
        public string? CharacterLastName { get; set; }
    }
}
