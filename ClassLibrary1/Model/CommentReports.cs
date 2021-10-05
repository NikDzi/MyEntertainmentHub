using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary1.Model
{
    public class CommentReports
    {

        [Key]
        public int ReportID { get; set; }
        public int CommentID { get; set; }
        public Comments Comment { get; set; }
        public string? UserID { get; set; }
    }
}
