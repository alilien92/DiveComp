using DiveComp.Data.Models;
using DiveComp.Data.Interfaces;
using DiveComp.Data.Helpers;
using DiveCompMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DiveCompMVC.Controllers
{
    public class ResultsController : Controller
    {
        private IParticipantRepo participants;

        public ActionResult Index()
        {
            
            return View("Results");
        }

        public ActionResult Results()
        {
            List<LeaderBoardModel> result = participants.GetContestResult(1);
            return View(result);
        }
    }
}
