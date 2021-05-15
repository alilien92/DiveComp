using DiveCompMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DiveCompMVC.Helpers;
using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;

namespace DiveCompMVC.Controllers
{
    public class EventController : Controller
    {

        private IEventsRepo events;

        public EventController(IEventsRepo _events) {
            this.events = _events;
        }

        [HttpPost]
        public IActionResult AddEvent(int contestid, EventTypeModel evt) {

            EventsModel new_evt = new EventsModel();
            new_evt.ContestId = contestid;
            new_evt.Type = evt;
            events.AddNewEvent(new_evt);

                return View("InputView", evt);
        }
    }
   
    }

