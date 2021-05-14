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
       
            return View();
        }

        public IActionResult LoadContest()
        {
            List<ContestModel> c;
            c = contests.GetAllContests();

            return View(c);
        }

        public IActionResult OpenEvents(int id)
        {
            List<EventsModel> evt;
            evt = events.GetAllEvents(id);

            return View(evt);
        }

        
        public IActionResult Leaderboard(int id)
        {
            List<LeaderBoardModel> board;
            board = participants.GetAllParticipants(id);

            return View(board);
        }
        
       
        
        [HttpPost]
        public IActionResult AddContest(ViewModel model) {
            
            
            contests.CreateNewContest(model.Contests);
            
            model.Contests.Id = contests.GetContestId(model.Contests.Name, model.Contests.Club);
            return View(model);

            }

        
    
}
}
