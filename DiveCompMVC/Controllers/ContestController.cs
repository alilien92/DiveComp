using DiveCompMVC.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DiveCompMVC.Helpers;
using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiveCompMVC.Controllers
{
    public class ContestController : Controller
    {
        private IContestRepo contests;
        private IParticipantRepo participants;
        private IEventTypeRepo eventTypes;


        public ContestController(IContestRepo _contests, IParticipantRepo _participants, IEventTypeRepo _eventTypes) {
            this.contests = _contests;
            this.participants = _participants;
            this.eventTypes = _eventTypes;
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

        
        public IActionResult Leaderboard(int id)
        {
            List<LeaderBoardModel> board;
            board = participants.GetAllParticipants(id);

            return View(board);
        }
        
       
       /* 
        [HttpPost]
        public ActionResult AddContest(ViewModel model) {
            
            
            contests.CreateNewContest(model.Contests);
            
            model.Contests.Id = contests.GetContestId(model.Contests.Name, model.Contests.Club);
            return View(model);

            }
       */
        
        public List<EventTypeModel> GetEventTypes(ViewModel model) {

            
           model.AllEventTypes = eventTypes.GetAllEventTypes();
            

            return model.AllEventTypes;
        }



    }
}
