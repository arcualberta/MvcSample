using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MvcSample.Controllers
{
    public class UploadController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            string uploadRoot = "C:\\Users\\Kamal\\Documents\\Projects\\MvcSample\\MvcSample\\App_Data\\Uploads";
            if (!Directory.Exists(uploadRoot))
                Directory.CreateDirectory(uploadRoot);

            foreach (var srFile in files)
            {
                if (srFile.Length > 0)
                {
                    string dstFileName = Path.Combine(uploadRoot, srFile.FileName);

                    using (var stream = new FileStream(dstFileName, FileMode.Create))
                    {
                        srFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, uploadRoot });
        }

    }
}