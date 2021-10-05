using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ClassLibrary1.Model
{
    public class Soundtracks
    {
        [Key]
        public int SoundtrackID { get; set; }
        public string Name { get; set; }
        public string? Notes { get; set; }
        public Media Media { get; set; }
        public int MediaID { get; set; }
    }
}
