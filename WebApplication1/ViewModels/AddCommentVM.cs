using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class AddCommentVM
    {
        public int CommentID { get; set; }
        public AppUser User { get; set; }
        public string? UserID { get; set; }
        public string CommentContent { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int? Score { get; set; }
        public Media Media { get; set; }
        public int? MediaID { get; set; }
        public int? Reports { get; set; }
        public string? RUID { get; set; }
        //lista reportova za komentar , ruid = reported user ids
        public List<CommentReports> RUIDS { get; set; }

    }
}
