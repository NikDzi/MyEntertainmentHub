using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class CastPerson
    {
        public int CastPersonID { get; set; }
        public Cast Cast { get; set; }
        public int CastID { get; set; }
        public Person Person { get; set; }
        public int PersonID { get; set; }
        public Character Character { get; set; }
        public int CharacterID { get; set; }
        //public string? CharacterFirstName { get; set; }
        //public string? CharacterLastName { get; set; }
    }
}
