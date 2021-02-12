using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace Lab02.Controllers
{
    public class FilesController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FilesController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "TextFiles");
            string fileName = Path.GetFileName(path);
            string[] files = Directory.GetFiles(fileName);

            return View(files);
        }

        [HttpGet]
        public IActionResult Content(int id)
        {
            string path = Path.Combine(_hostingEnvironment.ContentRootPath, "TextFiles");
            string finalPath = Path.Combine(path, "File" + id + ".txt");
            string[] texts = System.IO.File.ReadAllLines(finalPath);
            ViewBag.Data = texts;
            return View();
        }
    }
}