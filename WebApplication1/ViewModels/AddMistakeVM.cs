using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels
{
    public class AddMistakeVM
    {
        public int MistakeTicketID { get; set; }
        public List<SelectListItem> MistakeTicketTypeStavke { get; set; }
        public List<SelectListItem> MistakeTicketMediaType { get; set; }
        public int MistakeTicketTypeID { get; set; }
        public AppUser User { get; set; }
        public string? UserID { get; set; }
        //Identitytestvalue - Koristi se za prikazivanje lokacije mistake reporta
        public string? Identitytestvalue { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
        public Media Media { get; set; }
        public int MediaID { get; set; }
        public Person Person { get; set; }
        public int? PersonID { get; set; }
    }
}
