using DiveCompMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DiveCompMVC.Helpers;
using DiveComp.Data.Interfaces;
namespace DiveCompMVC.Controllers
{
    public class EventController : Controller
    {

        private IEventsRepo events;

        public EventController(IEventsRepo _events) {
            this.events = _events;
        }

        [HttpPost]
        public IActionResult AddEvent(ViewModel model) {
            
            model.Events.Id = events.GetEventId(model.Events.Name, model.Events.ContestId);

                events.AddNewEvent(model.Events);

                return View("InputView", model);
        }
    }
   
    }

