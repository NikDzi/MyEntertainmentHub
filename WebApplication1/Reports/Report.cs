using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempForReports
{
    public class Report
    {
        public string UserName { get; set; }
        public string Reason { get; set; }
        public int Duration { get; set; }

        public static List<Report> get()
        {
            return new List<Report>{};
        }
    }
}