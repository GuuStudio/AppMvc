using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.Services;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{

    [Route("He-mat-troi/[action]")]
    public class PlanetController : Controller
    {

        private readonly PlanetService _planetService ;
        private readonly ILogger<PlanetController> _logger ;
        public PlanetController (PlanetService planetService , ILogger<PlanetController> logger) {
            _planetService = planetService;
            _logger = logger;
        }

        [Route("Danh-sach-cac-hanh-tinh")]
        public IActionResult Index()
        {
            return View();
        }

        [BindProperty(SupportsGet = true, Name = "id")]
        public int id {get;set;}


        [Route("Chi_tiet_cac_hanh_tinh" , Order = 1, Name = "DetailStart")]
        public IActionResult Detail () {
            PlanetModel? planet = _planetService.Where( p => p.Id == id ).FirstOrDefault();
            if(planet != null) {
                if (!string.IsNullOrEmpty(planet.Name)) {
                    ViewData["Title"] = planet.Name.ToString() ?? "Not name";
                }
            } 
            return View(planet);
        }
    }
}