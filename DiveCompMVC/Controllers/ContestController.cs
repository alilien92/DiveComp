using DiveCompMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DiveCompMVC.Helpers;
using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;

namespace DiveCompMVC.Controllers
{
    public class ContestController : Controller
    {
        private IContestRepo contests;
        private IEventsRepo events;
        private IParticipantRepo participants;


        public ContestController(IContestRepo _contests, IEventsRepo _events, IParticipantRepo _participants) {
            this.contests = _contests;
            this.events = _events;
            this.participants = _participants;
        }
        
        public IActionResult NewContest() {
       
            return View("NewContest");
        }

        public IActionResult LoadContest()
        {
            List<ContestModel> c;
            c = contests.GetAllContests();

            return View(c);
        }

        public IActionResult OpenContest(int id)
        {
            List<EventsModel> evt;
            evt = events.GetAllEvents(id);

            return View(evt);
        }

        
        public IActionResult Leaderboard(int id)
        {
            List<LeaderBoardModel> board = new List<LeaderBoardModel>();
            board = participants.GetAllParticipants(id);

            return View(board);
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
