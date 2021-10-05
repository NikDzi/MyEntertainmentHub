using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;

namespace WebApplication1.ViewModels
{
    public class UserProfileVM
    {
        public string? UserID { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public int Rating { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Media> WatchListedMedia { get; set; }
       // public WatchListMedia WatchList { get; set; }
        public Image ProfilePicture { get; set; }
    }
}
