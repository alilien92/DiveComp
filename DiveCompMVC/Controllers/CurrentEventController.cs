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
        private IParticipantRepo participants;
        private IJudgeRepo judges;

        public CurrentEventController(IContestRepo _contests, IParticipantRepo _participants, IJudgeRepo _judges)
        {
            this.contests = _contests;
            this.participants = _participants;
            this.judges = _judges;
        }

        public IActionResult Overview(int id)
        {
            

            return View();
        }
        
    }
}
