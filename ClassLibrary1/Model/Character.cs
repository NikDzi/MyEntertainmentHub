using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1.Model
{
    public class Character
    {
        public int CharacterID { get; set; }
        [DisplayName("First Name")]
        [StringLength(100)]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        [StringLength(100)]
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
        [Required]
        [DisplayName("Gender")]
        public int GenderID { get; set; }
        [Range(0,100)]
        public int? Age { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateOfDeath { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
    }
}
