using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class Review
    {
        public int ReviewID { get; set; }
        //public AppUser User { get; set; }
        //public int UserID { get; set; }
        public Media Media { get; set; }
        public int MediaID { get; set; }
        public UserRating UserRating { get; set; }
        public int UserRatingID { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
