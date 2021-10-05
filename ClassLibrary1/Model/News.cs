using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class News
    {
        public int NewsID { get; set; }
        public string Title { get; set; }
        public string NewsContent { get; set; }
        public NewsType NewsType { get; set; }
        public int NewsTypeID { get; set; }
        public Media Media { get; set; }
        public int? MediaID { get; set; }
        public Person Person { get; set; }
        public int? PersonID { get; set; }
    }
}
