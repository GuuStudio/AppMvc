

using System.Reflection.Metadata.Ecma335;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers {
    public class FirstController : Controller {

        private readonly ILogger<FirstController> _logger;

        private readonly IWebHostEnvironment _env;

        public readonly ProductService _productService;

        public FirstController (ILogger<FirstController> logger , IWebHostEnvironment env , ProductService productService) {
            _logger = logger;
            _env = env;

            _productService = productService;

        }


        [TempData]
        public string? StatusMessage {set;get;}
        public string Index () {
            _logger.LogInformation("Index Action");
            return "It is the first string return by Index";
        }

        public IActionResult Readme() {
            ViewData["Title"] = "Trang readme";
            var content = @"
                            Xin chao cac ban,
                            Cac ban dang hoc ve AspNet mvc




                            XTL.NET
            
                        "; 
            return Content(content , "text/plain");
        }

        public IActionResult Bird () {
            string filePath = Path.Combine(_env.ContentRootPath, "Files" , "Bird.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            
            return File(bytes, "image/jpg");
        }

        public IActionResult IphonePrice() {
            return Json(
                new {
                    IphoneName = "Xsm",
                    Price = 2000
                }
            );
        }

        public IActionResult HelloMe(){
            string userName = "Phu";
            this.ViewData["Title"] = "Xin chao";
            return View("Xinchao3" , userName) ;
        } 

        
        [AcceptVerbs("Get")]        // Chấp nhận cho action được truy cập bằng method nào ?
        public IActionResult ViewProduct (int? id) {
            var product = _productService.Where( p => p.ID == id).FirstOrDefault();

            if (product == null) {
                StatusMessage = "Sản phẩm của bạn tìm không tồn tại";
                return Redirect(Url.Action("Index" , "Home") ?? "");



            }

            return View (product);
        }
    }
}