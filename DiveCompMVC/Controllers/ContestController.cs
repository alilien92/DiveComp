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
        private IDiverRepo divers;
        private IJudgeRepo judges;
        private IJudgeParticipantRepo judgeParticipants;

        public ContestController(IContestRepo _contests, IParticipantRepo _participants, IEventTypeRepo _eventTypes, IDiverRepo _divers, IJudgeRepo _judges, IJudgeParticipantRepo _judgeParticipants) {
            this.contests = _contests;
            this.participants = _participants;
            this.eventTypes = _eventTypes;
            this.divers = _divers;
            this.judges = _judges;
            this.judgeParticipants = _judgeParticipants;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateContest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContest(ContestModel model)
        {
            if (ModelState.IsValid)
            {
                contests.CreateNewContest(model);
                return RedirectToAction("AddDiversToContest", new { contestId = model.Id });
            }
            return View("CreateContest");
        }


        [HttpGet]
        public IActionResult AddDiversToContest(int contestId)
        {
            ViewModel vm = new ViewModel();
            List<ContestModel> singleContest = new List<ContestModel>() { contests.Get1Contest(contestId) };
            vm.AllContests = singleContest;
            vm.AllDivers = divers.GetDiverListByContest(contestId);
            return View(vm);
        }


        [HttpGet]
        public IActionResult AddDiver(int contestId)
        {
            ViewModel vm = new ViewModel();
            List<DiverModel> allDivers = new List<DiverModel>();
            vm.AllDivers = divers.GetDiversNotInContest(contestId);
            List<ContestModel> singleContest = new List<ContestModel>() { contests.Get1Contest(contestId) };
            vm.AllContests = singleContest;
            return View(vm);
        }

        public IActionResult AddDiverConfirmed(int diverId, int contestId)
        {
            participants.CreateNewParticipant(contests.Get1Contest(contestId), divers.Get1Diver(diverId));
            return RedirectToAction("AddDiversToContest", new { contestId = contestId });
        }



        [HttpGet]
        public IActionResult AddJudgesToContest(int contestId)
        {
            ViewModel vm = new ViewModel();
            vm.AllJudges = judges.GetJudgesByContest(contestId);
            List<ContestModel> singleContest = new List<ContestModel>() { contests.Get1Contest(contestId) };
            vm.AllContests = singleContest;
            return View("AddJudgesToContest", vm);
        }


        [HttpGet]
        public IActionResult AddJudge(int contestId)
        {
            ViewModel vm = new ViewModel();
            vm.AllJudges = judges.GetJudgesNotInContest(contestId);
            List<ContestModel> singleContest = new List<ContestModel>() { contests.Get1Contest(contestId) };
            vm.AllContests = singleContest;
            return View(vm);
        }

        public IActionResult AddJudgeConfirmed(int judgeId, int contestId)
        {
            judgeParticipants.CreateNewJudgeParticipant(contests.Get1Contest(contestId), judges.Get1Judge(judgeId));
            return RedirectToAction("AddJudgesToContest", new { contestId = contestId });
        }


    }
}

