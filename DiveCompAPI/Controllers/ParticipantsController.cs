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
    public class ParticipantsController : ControllerBase
    {

        private IParticipantsRepo participants;
        //Access to other tables
        private IDiverRepo divers;
        private IContestRepo contests;

        public ParticipantsController(IParticipantsRepo _participants, IDiverRepo _divers, IContestRepo _contests)
        {
            this.participants = _participants;
            this.divers = _divers;
            this.contests = _contests;
        }

        [HttpPost]
        public ActionResult<ParticipantsModel> AddParticipant(ParticipantsModel participant)
        {
            if (participants.CreateNewParticipant(contests.Get1Contest(participant.contestId), divers.Get1Diver(participant.diverId)))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<ParticipantsModel> Get1Participant(int id)
        {
            ParticipantsModel participant = participants.Get1Participant(id);
            if(participant != null)
            {
                return participant;
            }
            return NotFound();
        }
    }
}
