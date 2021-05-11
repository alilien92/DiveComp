using DiveComp.Data.Models;
using DiveCompMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;




namespace DiveCompMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public async Task<ActionResult> Index() {
            List<FinaDifficultyModel> finaDifficulties = new List<FinaDifficultyModel>();
            using (var client = new HttpClient()) {

                var Res = await client.GetAsync("https://localhost:44339/api/FinaDifficulty/dives/3");

                 
                
                    //Storing the response details recieved from web api   
                    string FinaResponse = await Res.Content.ReadAsStringAsync();

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    finaDifficulties = JsonConvert.DeserializeObject<List<FinaDifficultyModel>>(FinaResponse);

                
            }
                return View(finaDifficulties);
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        
    }
}
