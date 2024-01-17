

using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers {

    [Area("ProductManage")]
    public class ProductController : Controller {
        private readonly ProductService _productService ;
        private readonly ILogger<ProductController> _logger ;

        public ProductController(ILogger<ProductController> logger , ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }



        // Areas/AreaName/Views/Controller/Action.cshtml
        public IActionResult Index () {

            List<ProductModel> products = _productService.OrderBy(p => p.Name).ToList();
            return View(products);
        }
    }
}