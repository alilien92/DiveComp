using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveCompMVC.Models;
using DiveComp.Data.Interfaces;
using DiveCompMVC.Helpers;

namespace DiveCompMVC.Controllers
{
    public class CurrentEventController : Controller
    {
        private IContestRepo contests;
        private IParticipantRepo participants;
        private IJudgeRepo judges;
        private IDiverRepo divers;
        private IFinaDifficultyRepo fina;

        public CurrentEventController(IContestRepo _contests, IParticipantRepo _participants, IJudgeRepo _judges, IDiverRepo _divers, IFinaDifficultyRepo _fina)
        {
            this.contests = _contests;
            this.participants = _participants;
            this.judges = _judges;
            this.divers = _divers;
            this.fina = _fina;

        }

        public IActionResult Overview(int id)
        {
            RepoHelper repo = new RepoHelper(fina, contests);
            ActiveContestVM contest = repo.RetrieveActiveContest(id);

            return View(contest);
        }

        public IActionResult StartContest(int id)
        {
           
            RepoHelper repo = new RepoHelper(fina, contests);
            ActiveContestVM contest = repo.RetrieveActiveContest(id);

            return View(contest);
        }


        
        public IActionResult PerformJump(int diverid, int contestid)
        {
            
            RepoHelper repo = new RepoHelper(fina, contests);
            ActiveContestVM contest = repo.RetrieveActiveContest(contestid);
            contest.diver = divers.Get1Diver(diverid);

            return View(contest);
        }


        [HttpPost]
        public IActionResult SubmitScore(ActiveContestVM model)
        {

            RepoHelper repo = new RepoHelper(fina, contests);
            float median = repo.CalculateMedian(model.score1, model.score2, model.score3);
            float mod = fina.DetermineDiveType(model.divepos, model.contest.Type.Height, model.currentDiffMod.DiveCodeNumber);
            if(mod == 0)
            {
                mod = 1.5F;
            }

            float newscore = median * mod;
            participants.UpdateScore(model.contest.Id, model.diver.Id, newscore);

            return RedirectToAction("StartContest", new { id = model.contest.Id });
            
        }
        public IActionResult FinalScreen(int id) {

            RepoHelper repo = new RepoHelper(fina, contests);
            ActiveContestVM contest = repo.RetrieveActiveContest(id);
            return View(contest);
        }
        
    }
}
