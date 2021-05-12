using DiveCompMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DiveCompMVC.Helpers;
using DiveComp.Data.Interfaces;

namespace DiveCompMVC.Controllers
{
    public class ContestController : Controller
    {
        private IContestRepo contests;


        public ContestController(IContestRepo _contests) {
            this.contests = _contests;
        }
        
        public IActionResult NewContest() {
       
            return View("NewContest");
        }
        
       
        
        [HttpPost]
        public IActionResult AddContest(ViewModel model) {
            
            
            contests.CreateNewContest(model.Contests);
            
            model.Contests.Id = contests.GetContestId(model.Contests.Name, model.Contests.Club);
            return View("InputView", model);

            }

        [HttpPost]
        public async Task<ActionResult> AddJudge(ViewModel model) {

            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("https://localhost:44393/api/");

                //HTTP POST
                var postTask = await client.PostAsJsonAsync("judge", model.Judges);

                
                return View("InputView", model);
            }
        }
    
}
}
