using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class PersonDetailVM
    {
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? DateOfBirth { get; set; }
        public string? DateOfDeath { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public int CrewPersonID { get; set; }
        public List<CrewPersonVM> CrewPersonStavke { get; set; }
        public int CastPersonID { get; set; }
        public List<CastPersonVM> CastPersonStavke { get; set; }
        public int PersonOccupationID { get; set; }
        public List<PersonOccupationVM> PersonOccupationStavke { get; set; }
        //new below
        public List<ImageVM> ImageList { get; set; }
    }
}

