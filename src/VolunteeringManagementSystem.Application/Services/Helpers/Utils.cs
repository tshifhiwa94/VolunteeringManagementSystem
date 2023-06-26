using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VolunteeringManagementSystem.Services.Helpers
{
    public static class Utils
    {
        public static bool IsImage(IFormFile file)
        {
            return (file.ContentType.ToLower() != "image/jpg" ||
                    file.ContentType.ToLower() != "image/jpeg" ||
                    file.ContentType.ToLower() != "image/pjpeg" ||
                    file.ContentType.ToLower() != "image/gif" ||
                    file.ContentType.ToLower() != "image/x-png" ||
                    file.ContentType.ToLower() != "video/mp4");
        }
    }
}
