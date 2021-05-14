using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveCompMVC.Models;
using DiveComp.Data.Interfaces;

namespace DiveCompMVC.Controllers
{
    public class CurrentEventController : Controller
    {
        private IContestRepo contests;
        private IEventsRepo events;
        private IParticipantRepo participants;
        private IJudgeRepo judges;

        public CurrentEventController(IContestRepo _contests, IEventsRepo _events, IParticipantRepo _participants, IJudgeRepo _judges)
        {
            this.contests = _contests;
            this.events = _events;
            this.participants = _participants;
            this.judges = _judges;
        }

        public IActionResult Index(int id)
        {
            ActiveContestModel active = new ActiveContestModel();
            active.contest = contests.Get1Contest(id);
            active.judge = judges.GetJudgesByContest(id);
            active.events = events.GetEventsForContest(id);


            return View(active);
        }
    }
}
