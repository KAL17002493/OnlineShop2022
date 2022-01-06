using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop2022.Helpers
{
    public class Images
    {
        private IWebHostEnvironment _webHostEnvironment;

        public Images(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string Upload(IFormFile file, string path)
        {
            string ext = Path.GetExtension(file.FileName);
            string root = _webHostEnvironment.WebRootPath;
            string webPath = $"{root}{path}";
            string newFileName = Guid.NewGuid().ToString().ToLower();
            string fileName = $"{webPath}{newFileName}{ext}";
            Directory.CreateDirectory(webPath);

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {   
                file.CopyToAsync(fileStream);
            }

            return $"{path}{newFileName}{ext}";
        }

        //Checks if path to the image exists if it does the path is deleted
        public bool Delete(string path)
        {
            path = _webHostEnvironment.WebRootPath + path;

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
                return true;
            }
            return false;

        }
    }
}
