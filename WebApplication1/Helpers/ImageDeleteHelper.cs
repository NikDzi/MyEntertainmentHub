using ClassLibrary1.Model;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.ViewModels;

namespace WebApplication1.Helpers
{
    public class ImageDeleteHelper
    {
        private readonly MojDbContext db;
        public ImageDeleteHelper(MojDbContext context)
        {
            db = context;
        }

        public  void IzbrisiSlike(List<Image> list, IWebHostEnvironment hostingEnvironment)
        {
            foreach (var x in list)
            {
                Image i = db.Image.Find(x.ImageID);

                //brisanje slike iz foldera
                string filePath = hostingEnvironment.WebRootPath + "\\uploads\\" + i.ImageUniqueFilename;

                if (System.IO.File.Exists(filePath))
                {
                    System.GC.Collect();
                    System.GC.WaitForPendingFinalizers();
                    System.IO.File.Delete(filePath);
                }
            }
        }
    }
}
