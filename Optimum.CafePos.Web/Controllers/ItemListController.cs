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

        string apiBaseUrl = "https://optimum.co.in/cafeposapp/Android/";

        // requires using Microsoft.Extensions.Configuration;
        private readonly IConfiguration Configuration;

        public ItemListController(IConfiguration configuration)
        {
            Configuration = configuration;
        }




        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            // Retrieve the session value
            IEnumerable<ItemHead> storedValue = HttpContext.Session.Get<IEnumerable<ItemHead>>("Person");

            var httpClientWrapper = new HttpClientWrapper<IEnumerable<Item>>(apiBaseUrl);

            // Making a GET request
            var result = await httpClientWrapper.GetAsync("androiditemmaster?locationShortName=sohanram&dishHeadCode=7");
            //Set value in Session object.
            HttpContext.Session.Add<IEnumerable<Item>>("Item", result);

            return View(storedValue);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}