using DiveCompMVC.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DiveCompMVC.Helpers;
using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;

using Microsoft.AspNetCore.Mvc;

namespace DiveCompMVC.Controllers
{
    public class EventTypeController : Controller
    {

        private IEventTypeRepo eventTypes;

        public EventTypeController(IEventTypeRepo _eventTypes) {
            this.eventTypes = _eventTypes;
        }
        public IActionResult AddEventType() {
            return View("AddEventType");
        }
        
        [HttpPost]
        public IActionResult AddEventType(EventTypeModel model) {
            if (ModelState.IsValid) {
                eventTypes.AddNewEventType(model);
                return View();
            }
            return View();
        }
        
        
    }
}
