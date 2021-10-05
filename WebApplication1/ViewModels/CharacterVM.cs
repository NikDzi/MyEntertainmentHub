using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModels
{
    public class CharacterVM
    {
        public int CharacterID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ImageVM Thumbnail { get; set; }
    }
}
