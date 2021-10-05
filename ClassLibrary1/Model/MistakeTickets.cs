using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Model
{
    public class MistakeTickets
    {
        [Key]
        public int MistakeTicketID { get; set; }
        public MistakeTicketType MistakeTicketType { get; set; }
        public int MistakeTicketTypeID { get; set; }
        public AppUser User { get; set; }
        public string? UserID { get; set; }
        public string? IdentityTestValue { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public Media Media { get; set; }
        public int? MediaID { get; set; }
        public Person Person { get; set; }
        public int? PersonID { get; set; }
    }
}
