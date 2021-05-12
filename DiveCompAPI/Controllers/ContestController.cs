using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using DiveComp.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveComp.Data.Helpers;

namespace DiveCompAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase {
        private IContestRepo contests;


        public ContestController(IContestRepo _contests) {
            this.contests = _contests;
        }

        [HttpPost]
        public ActionResult<ContestModel> PostContest(ContestModel contest) {
            if (contests.CreateNewContest(contest)) {
                return contest;
            }
            return BadRequest();
        }


        public ActionResult<ContestModel> GetContest(int id) {
            ContestModel contest = contests.Get1Contest(id);
            if (contest != null) {
                return contest;
            }
            return NotFound();
        }

        [HttpGet("{Name}/{Club}")]
        public int GetContestId(string name, string club) {
            ContestModel contest = new ContestModel();
             contest.Id = contests.GetContestId(name, club);
            return contest.Id;
        }

        

    }
}
