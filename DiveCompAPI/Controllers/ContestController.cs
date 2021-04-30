using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using DiveComp.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiveCompAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController : ControllerBase
    {
        private IContestRepo contests;

        private IClubRepo clubs;

        public ContestController(IContestRepo _contests, IClubRepo _clubs)
        {
            this.contests = _contests;
            this.clubs = _clubs;
        }

        [HttpPost]
        public ActionResult<ContestModel> PostContest(ContestModel contest)
        {
            if(contests.CreateNewContest(clubs.Get1Club(contest.clubId)))
            {
                return contest;
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<ContestModel> GetContest(int id)
        {
            ContestModel contest = contests.Get1Contest(id);
            if(contest != null)
            {
                return contest;
            }
            return NotFound();
        }

    }
}
