using DiveComp.Data.Models;
using DiveCompMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;


namespace DiveCompMVC.Controllers
{
    public class DiverController : Controller
    {
        public IActionResult Index() {
            return View("AddDiver");
        }
        [HttpPost]
        public async Task<ActionResult> AddDiver(ViewModel model) {

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("https://localhost:44393/api/");

                //HTTP POST
                var postTask = await client.PostAsJsonAsync("diver", model.Divers);
                
                    ModelState.Clear();
                    ViewBag.Message = "Diver has been added!";
                    return View("AddDiver");
                         }
        }
    }
}
