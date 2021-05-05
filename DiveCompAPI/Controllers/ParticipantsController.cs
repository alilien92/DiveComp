using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using MySqlConnector;


namespace DiveCompAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {

        private IParticipantRepo participants;
        //Access to other tables
        private IDiverRepo divers;
        private IEventsRepo events;

        public ParticipantsController(IParticipantRepo _participants, IDiverRepo _divers, IEventsRepo _evt)
        {
            this.participants = _participants;
            this.divers = _divers;
            this.events = _evt;
        }

        [HttpPost]
        public ActionResult<ParticipantsModel> AddParticipant(ParticipantsModel participant)
        {

            if (participants.CreateNewParticipant(events.GetEvent(participant.eventId), divers.Get1Diver(participant.diverId)))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{eventid}")]
        public ActionResult<List<LeaderBoardModel>> GetParticipants(int eventid)
        {
            var result = participants.GetAllParticipants(eventid);
            return result;
        }

        [HttpPut("{diverid}/{newscore}")]
        //Lagrad Procedur behövs
        public ActionResult<ParticipantsModel> UpdateDiverScore(int diverId, float newscore)
        {
            participants.UpdateScore(diverId, newscore);
            return Ok();
        }

        [HttpDelete("{diverid}")]

        public ActionResult<ParticipantsModel> RemoveParticipant(int diverid)
        {
            if(participants.DeleteParticipant(diverid))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
