using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Model
{
    public class UserTickets
    {
        [Key]
        public int UserTicketID { get; set; }
        public UserTicketType UserTicketType { get; set; }
        public int UserTicketTypeID { get; set; }
        //public AppUser TicketSender { get; set; }
        //public int TicketSenderID { get; set; }
        //public AppUser ReportedUser { get; set; }
        //public int ReportedUserID { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
