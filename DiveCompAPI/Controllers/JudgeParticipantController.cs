using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
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
    public class JudgeParticipantController : ControllerBase
    {

        private IJudgeParticipantRepo judgeParticipants;
        //Access to other tables
        private IJudgeRepo judges;
        private IContestRepo contests;

        public JudgeParticipantController(IJudgeParticipantRepo _judgeparticipant, IJudgeRepo _judges, IContestRepo _contests)
        {
            this.judgeParticipants = _judgeparticipant;
            this.judges = _judges;
            this.contests = _contests;
        }

        [HttpPost]
        public ActionResult<JudgeParticipantModel> AddParticipant(JudgeParticipantModel judgeParticipant)
        {
            if (judgeParticipants.CreateNewJudgeParticipant(contests.Get1Contest(judgeParticipant.contestId), judges.Get1Judge(judgeParticipant.judgeId)))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<JudgeParticipantModel> Get1JudgeParticipant(int id)
        {
            JudgeParticipantModel judgeParticipant = judgeParticipants.Get1JudgeParticipant(id);
            if (judgeParticipant != null)
            {
                return judgeParticipant;
            }
            return NotFound();
        }
    }
}
