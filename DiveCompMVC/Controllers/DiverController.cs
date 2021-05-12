using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveComp.Data.Models;
using System.Net.Http;
using DiveComp.Data.Interfaces;

namespace DiveCompMVC.Controllers
{
    public class DiverController : Controller
    {
        private IDiverRepo divers;


        public DiverController(IDiverRepo _divers) {
            this.divers = _divers;
        }
        public IActionResult Index() {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> AddDiver(DiverModel model) {

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("https://localhost:44393/api/");

                //HTTP POST
                var postTask = await client.PostAsJsonAsync("diver", model.Divers);


                return View("InputView", model);
            }
        }
    }
}
