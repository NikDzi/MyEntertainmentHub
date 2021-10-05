using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class CrewPerson
    {
        public int CrewPersonID { get; set; }
        public Crew Crew { get; set; }
        public int CrewID { get; set; }
        public Person Person { get; set; }
        public int PersonID { get; set; }
        public Occupation Occupation { get; set; }
        public int? OccupationID { get; set; }
    }
}
