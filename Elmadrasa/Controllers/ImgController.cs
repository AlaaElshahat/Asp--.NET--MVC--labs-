using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;

namespace WebApplicationlab09.Controllers
{
    public class ImgController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ImgController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UploadImage()
        {
            
            // Handle errors
            // ...

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // Save the uploaded file to a location on the server
                var fileName = Path.GetFileName(imageFile.FileName);
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Optionally, save the file path to a database
                // ...

                return RedirectToAction("Index","Img");
            }

            // Handle errors
            // ...

            return View();
        }
    }
}
