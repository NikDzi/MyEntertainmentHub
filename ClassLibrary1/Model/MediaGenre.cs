using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class MediaGenre
    {
        public int MediaGenreID { get; set; }
        public Media Media { get; set; }
        public int MediaID { get; set; }
        public Genre Genre { get; set; }
        public int GenreID { get; set; }
    }
}
