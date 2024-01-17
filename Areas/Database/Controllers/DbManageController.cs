


using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Areas.Database.Controllers {



    [Area("Database")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller {

        private readonly AppDbContext _context ;

        public DbManageController(AppDbContext context)
        {
            _context = context;
        }


        [TempData]
        public string? StatusMessage {set;get;}

    
        public IActionResult Index () {
            return View ();
        }

        [HttpGet]
        public IActionResult DeleteDb () {
            return View ();
            
        }
        [HttpGet]
        public IActionResult CreateDb () {
            return View ();
            
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync () {
            var result = await _context.Database.EnsureDeletedAsync();
            StatusMessage = result ? "Thành công xóa cơ sở dữ liệu" : "Xóa thất bại";

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> CreateDbAsync () {
            await _context.Database.MigrateAsync();
            StatusMessage = "Thành công tạo cơ sở dữ liệu" ;

            return RedirectToAction(nameof(Index));
        }
    }
}