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
    public class EventsController : ControllerBase
    {

        private IEventsRepo events;

        public EventsController(IEventsRepo _events)
        {
            this.events = _events;
        }

        [HttpPost]
        public ActionResult<EventsModel> AddEvent(EventsModel evt)
        {
            events.AddNewEvent(evt);
            
            return Ok();
            
        }

        [HttpGet]
        public ActionResult<EventsModel> GetEvent(int id)
        {
            EventsModel evt = events.GetEvent(id);
            if(evt != null)
            {
                return evt;
            }
            return NotFound();
        }
    }
}
