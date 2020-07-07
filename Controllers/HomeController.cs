using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AprendiendoWeb.Models;
using DNTBreadCrumb.Core;
using Microsoft.Extensions.Options;
using AprendiendoWeb.Models.ConstantesSistema;

namespace AprendiendoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<GlobalSettings> _gSettings;
        private readonly IOptions<AppSettings> _appSettings;

        public HomeController(IOptions<GlobalSettings> gSettings, IOptions<AppSettings> appSettings)
        {
            _gSettings = gSettings;
            _appSettings = appSettings;
        }

        public IActionResult Index()
        {
            ViewBag.NombreCompania = _gSettings.Value.NombreCompania;
            return View();
        }

        public IActionResult Privacy()
        {
            _gSettings.Value.NombreCompania = "Monográfico 2-2020";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [BreadCrumb(Title = "AdminLte", Order = 0)]
        public IActionResult AdminLte()
        {
            return View();
        }
    }
}
