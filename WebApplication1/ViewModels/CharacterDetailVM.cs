using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class CharacterDetailVM
    {
        public int CharacterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? DateOfDeath { get; set; }
        public int? Age { get; set; }
        public string? Description { get; set; }
        public string Gender { get; set; }
        public List<CastPersonVM> CastPersonStavke { get; set; }
        //new below
        public List<ImageVM> ImageList { get; set; }
    }
}
