using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using DiveCompMVC.Helpers;
using DiveCompMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiveCompMVC.Controllers
{
    public class LoadContestController : Controller
    {
        private IContestRepo contests;
        private IFinaDifficultyRepo fina;

        public LoadContestController(IContestRepo _contests, IFinaDifficultyRepo _fina)
        {
            this.contests = _contests;
            this.fina = _fina;
        }

        public IActionResult Index()
        {
            List<ContestModel> existingContests = contests.GetAllContests();

            return View(existingContests);
        }

        public IActionResult SelectedContest(int id)
        {
            RepoHelper repo = new RepoHelper(fina, contests);
            ActiveContestVM contest = repo.RetrieveActiveContest(id);

            return View(contest);

        }
    }
}
