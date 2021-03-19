using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Sewit.PhotoUploadService.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.Services
{
    public class PhotoUploadService : IPhotoUploadService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PhotoUploadService(IWebHostEnvironment hostingEnviroment)
        {
            _hostingEnvironment = hostingEnviroment;
        }

        public string UploadImage(IFormFile file)
        {
            string toFolder = Path.Combine(_hostingEnvironment.WebRootPath, "posters");
            string uniqueFileName = Guid.NewGuid().ToString() + ".jpg";
            string filePath = Path.Combine(toFolder, uniqueFileName);
            file.CopyTo(new FileStream(filePath, FileMode.Create));
            return Path.Combine("photos", uniqueFileName);
        }
    }
}
