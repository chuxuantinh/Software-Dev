using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ConsultationDemo.Models;
using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using Microsoft.AspNetCore.Http;
using ConsultationDemo.CloudinaryHepler;

namespace ConsultationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Cloudinary cloudinary;

        public HomeController(ILogger<HomeController> logger, Cloudinary cloudinary)
        {
            _logger = logger;
            this.cloudinary = cloudinary;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(ICollection<IFormFile> files)
        {
            var result = await CloudinaryExtension.UploadAsync(this.cloudinary, files);

            //var uploadParams = new ImageUploadParams()
            //{
            //    File = new FileDescription(@"F:\photos\module-6.jpg")
            //};
            //var uploadResult = await cloudinary.UploadAsync(uploadParams);

            return this.Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
