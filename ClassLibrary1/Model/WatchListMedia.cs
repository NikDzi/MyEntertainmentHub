using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace ClassLibrary1.Model
{
    public class WatchListMedia
    {

        public int? WatchListMediaID { get; set; }
        public List<Media>? Media { get; set; }
        public int? MediaID { get; set; }
        //public WatchStatus WatchStatus { get; set; }
        //public int? WatchStatusID { get; set; }
        public string? Watchstatus { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateFinished { get; set; }
        public int? Progress { get; set; }
        public AppUser User { get; set; }
        public string? UserID { get; set; }

    }
}
