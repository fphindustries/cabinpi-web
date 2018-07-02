using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using CabinPi.Web.Infrastructure;

namespace CabinPi.Web.Pages
{
    public class CameraModel : PageModel
    {
        private AppOptions _appOptions;

        public CameraModel(IOptions<AppOptions> optionsAccessor)
        {
            _appOptions = optionsAccessor.Value;
        }
        public void OnGet()
        {

        }

        public ActionResult OnGetLatestImage()
        {
            var directory = new DirectoryInfo(_appOptions.ImageDirectory);
            var newestFile = directory.GetFiles().OrderByDescending(f => f.CreationTime).FirstOrDefault();
            var imageBytes = System.IO.File.ReadAllBytes(newestFile.FullName);
            return File(imageBytes, "image/jpg", newestFile.Name);
        }

    }
}