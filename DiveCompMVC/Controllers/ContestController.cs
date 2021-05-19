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
                return View();
                //model.Id
            }
            return Index();
        }

        public IActionResult AddDiversToContest(int diverId, int contestId)
        {
            participants.CreateNewParticipant(contests.Get1Contest(contestId), divers.Get1Diver(diverId));
            ViewModel vm = new ViewModel();
            vm.AllDivers = divers.GetAllDivers();
            List<ContestModel> singleContest = new List<ContestModel>() { contests.Get1Contest(contestId) };
            vm.AllContests = singleContest;
            List<ParticipantsModel> participantsInContest = new List<ParticipantsModel>();

            vm.AllParticipants = participantsInContest;
            return View("AddDiversToContest", vm);
        }

        [HttpPost]
        public IActionResult AddDiversToContest(ContestModel model)
        //int contestId
        {
            if (ModelState.IsValid)
            {
                contests.CreateNewContest(model);
                ViewModel vm = new ViewModel();
                vm.AllDivers = divers.GetAllDivers();
                List<ContestModel> singleContest = new List<ContestModel>() { contests.Get1Contest(model.Id) };
                vm.AllContests = singleContest;
                List<ParticipantsModel> participantsInContest = new List<ParticipantsModel>();

                vm.AllParticipants = participantsInContest;
                return View(vm);
            }
            return Index();
        }

        [HttpGet]
        public IActionResult AddDiver(int diverId, int contestId)
        {
            ViewModel vm = new ViewModel();
            List<DiverModel> singleDiver = new List<DiverModel>() { divers.Get1Diver(diverId) };
            vm.AllDivers = singleDiver;
            List<ContestModel> singleContest = new List<ContestModel>() { contests.Get1Contest(contestId) };
            vm.AllContests = singleContest;
            return View(vm);
        }






        public IActionResult ConfirmAddedDivers(int contestId)
        {
            ViewModel vm = new ViewModel();
            vm.AllJudges = judges.GetAllJudges();
            List<ContestModel> singleContest = new List<ContestModel>() { contests.Get1Contest(contestId) };
            vm.AllContests = singleContest;
            List<JudgeParticipantModel> judgeParticipantsInContest = new List<JudgeParticipantModel>();

            vm.AllJudgesParticipants = judgeParticipantsInContest;
            return View("AddJudgesToContest", vm);
        }



        public IActionResult AddJudgesToContest(int judgeId, int contestId)
        {
            judgeParticipants.CreateNewJudgeParticipant(contests.Get1Contest(contestId), judges.Get1Judge(judgeId));
            ViewModel vm = new ViewModel();
            vm.AllJudges = judges.GetAllJudges();
            List<ContestModel> singleContest = new List<ContestModel>() { contests.Get1Contest(contestId) };
            vm.AllContests = singleContest;
            List<JudgeParticipantModel> judgeParticipantsInContest = new List<JudgeParticipantModel>();

            vm.AllJudgesParticipants = judgeParticipantsInContest;
            return View("AddJudgesToContest", vm);
        }



        [HttpGet]
        public IActionResult AddJudge(int judgeId, int contestId)
        {
            ViewModel vm = new ViewModel();
            List<JudgeModel> singleJudge = new List<JudgeModel>() { judges.Get1Judge(judgeId) };
            vm.AllJudges = singleJudge;
            List<ContestModel> singleContest = new List<ContestModel>() { contests.Get1Contest(contestId) };
            vm.AllContests = singleContest;
            return View(vm);
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
        
        public List<EventTypeModel> GetEventTypes(ViewModel model) {

            
           model.AllEventTypes = eventTypes.GetAllEventTypes();
            

            return model.AllEventTypes;
        }
    }
}

