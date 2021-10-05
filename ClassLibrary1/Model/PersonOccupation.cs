using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class PersonOccupation
    {
        public int PersonOccupationID { get; set; }
        public Person Person { get; set; }
        public int PersonID { get; set; }
        public Occupation Occupation { get; set; }
        public int OccupationID { get; set; }
    }
}
