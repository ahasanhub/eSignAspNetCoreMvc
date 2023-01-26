using eSignAspNetCore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace eSignAspNetCore.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        public AuthorController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult save(Author author)
        {
            var filename = author.Name + ".png";
            var filepath = Path.Combine(_hostingEnvironment.WebRootPath,"images",filename);
            System.IO.File.WriteAllBytes(filepath,Convert.FromBase64String(author.Signature.Replace("data:image/png;base64,",string.Empty)));
            return RedirectToAction("SavedMessage");
        }
        public IActionResult SavedMessage()
        {
            return View();
        }
    }
}
