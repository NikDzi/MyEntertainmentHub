using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Model
{
    public class TechnicalSpecifications
    {
        public int TechnicalSpecificationsID { get; set; }
        public string? AspectRatio { get; set; }
        public string? Camera { get; set; }
        public string? Laboratory { get; set; }
        public string? NegativeFormat { get; set; }
        public string? CinematographicProcess { get; set; }
        public string? PrintedFilmFormat { get; set; }
        public Color Color { get; set; }
        public int? ColorID { get; set; }
        public SoundMix SoundMix { get; set; }
        public int? SoundMixID { get; set; }
        public int? MediaID { get; set; }
    }
}
