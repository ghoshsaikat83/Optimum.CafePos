using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Optimum.CafePos.Models;
using Optimum.CafePos.Web.Models;
using System.Diagnostics;
using System.Text.Json.Serialization;
using Optimum.CafePos.WebServices;
using Optimum.CafePos.Models.Constants;
using Microsoft.AspNetCore.Http;

namespace Optimum.CafePos.Web.Controllers
{
    public class ItemListController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string apiBaseUrl = "https://optimum.co.in/cafeposapp/Android/";


        public ItemListController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}