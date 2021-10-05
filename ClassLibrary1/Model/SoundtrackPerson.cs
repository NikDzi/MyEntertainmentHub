using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class SoundtrackPerson
    {
        public int SoundtrackPersonID { get; set; }
        public Soundtracks Soundtrack { get; set; }
        public int SoundtrackID { get; set; }
        public Person PerformedBy { get; set; }
        public int PerformedByID { get; set; }
        public Person WrittenBy { get; set; }
        public int? WrittenByID { get; set; }
        public Person ProducedBy { get; set; }
        public int? ProducedByID { get; set; }
        public Person ConductedBy { get; set; }
        public int? ConductedByID { get; set; }

    }
}
