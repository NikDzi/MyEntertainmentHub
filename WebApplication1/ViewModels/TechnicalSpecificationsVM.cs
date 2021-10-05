using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.ViewModels
{
    public class TechnicalSpecificationsVM
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
            public List <SelectListItem>? ColorStavke { get; set; }
            public SoundMix SoundMix { get; set; }
            public int? SoundMixID { get; set; }
            public string? SoundComposer { get; set; }
            public int? MediaID { get; set; }


    }
}
