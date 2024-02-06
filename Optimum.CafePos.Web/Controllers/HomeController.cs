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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        readonly string apiBaseUrl = "https://optimum.co.in/cafeposapp/Android/";
        private readonly IConfiguration Configuration;

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {

            var httpClientWrapper = new HttpClientWrapper<IEnumerable<ItemHead>>(apiBaseUrl);
            var location = Configuration["LocationName"];
            // Making a GET request
            var result = await httpClientWrapper.GetAsync("androiddishhead?locationShortName=" + location + "");
            //Set value in Session object.
            HttpContext.Session.Add<IEnumerable<ItemHead>>("Person", result);


            // Making a POST request
            // var requestData = new MyRequestClass { /* ... */ };
            // var postResult = await httpClientWrapper.PostAsync<MyRequestClass, MyResponseClass>("/endpoint", requestData);


            /* List<ItemHead> itemHeadList = new List<ItemHead>();
             HttpResponseMessage httpResponseMessage = _httpClient.GetAsync(baseAddress + "androiddishhead?locationShortName=sohanram").Result;

             if(httpResponseMessage.IsSuccessStatusCode)
             {
                 string data = httpResponseMessage.Content.ReadAsStringAsync().Result;
                 itemHeadList = JsonConvert.DeserializeObject<List<ItemHead>>(data);
             }    
            */

            var category = result.First();
            category.IsSelected = true;

            // ViewBag.Products = await _shoppingService.GetRaws(category.DishHeadCode);
            ViewBag.CategoryName = category.dishHeadName;


            return View(result);
        }



        public IActionResult GetOtp()
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