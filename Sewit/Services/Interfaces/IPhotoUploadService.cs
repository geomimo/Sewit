using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sewit.PhotoUploadService.Interfaces
{
    public interface IPhotoUploadService
    {
        public string UploadImage(IFormFile file);

    }
}
