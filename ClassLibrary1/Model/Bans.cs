using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1.Model
{
    public class Bans
    {
        [Key]
        public int BanID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Reason { get; set; }
        public int Duration { get; set; }
    }
}
