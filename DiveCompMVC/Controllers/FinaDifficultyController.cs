using DiveComp.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DiveCompMVC.Controllers
{
    public class FinaDifficultyController : Controller
    {
        public async Task<ActionResult> FinaDifficulty() {
            List<FinaDifficultyModel> finaDifficulties = new List<FinaDifficultyModel>();
            using (var client = new HttpClient()) {

                var Res = await client.GetAsync("https://localhost:44393/api/FinaDifficulty/dives/3");



                //Storing the response details recieved from web api   
                string FinaResponse = await Res.Content.ReadAsStringAsync();

                //Deserializing the response recieved from web api and storing into the Employee list  
                finaDifficulties = JsonConvert.DeserializeObject<List<FinaDifficultyModel>>(FinaResponse);


            }
            return View(finaDifficulties);
        }
    }
}
