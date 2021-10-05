using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Model
{
    public class Comments
    {
        [Key] 
        public int CommentID { get; set; }
        public AppUser User { get; set; }
        public string? UserID { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int? Score { get; set; }
        public Media Media { get; set; }
        public int? MediaID { get; set; }
        public int? Reports { get; set; }
        public List<CommentReports> RUID { get; set; }
    }
}
