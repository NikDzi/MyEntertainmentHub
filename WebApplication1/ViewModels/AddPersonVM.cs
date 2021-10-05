using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels
{
    public class AddPersonVM
    {
        public int PersonID { get; set; }
        [Required]
        [DisplayName("First Name")]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        [StringLength(100)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }
        public int? CityID { get; set; }
        public List<SelectListItem> CityStavke { get; set; }
        public List<int> ListOfOccupations { get; set; } // check later
        public List<CheckBoxItem> OccupationStavke { get; set; }
    }
}
