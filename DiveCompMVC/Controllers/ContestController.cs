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
        private IEventsRepo events;
        private IParticipantRepo participants;
        private IEventTypeRepo eventTypes;


        public ContestController(IContestRepo _contests, IEventsRepo _events, IParticipantRepo _participants, IEventTypeRepo _eventTypes) {
            this.contests = _contests;
            this.events = _events;
            this.participants = _participants;
            this.eventTypes = _eventTypes;
        }
        
        public IActionResult NewContest() {
            ViewModel vm = new ViewModel();
            vm.AllEventTypes = GetEventTypes(vm);


            return View(vm);
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
        public ActionResult AddContest(ViewModel model) {
            
            
            contests.CreateNewContest(model.Contests);
            
            model.Contests.Id = contests.GetContestId(model.Contests.Name, model.Contests.Club);
            return View(model);

            }
        
        public List<EventTypeModel> GetEventTypes(ViewModel model) {

            
           model.AllEventTypes = eventTypes.GetAllEventTypes();
            

            return model.AllEventTypes;
        }



    }
}
