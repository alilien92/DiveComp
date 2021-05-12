using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveComp.Data.Models;

namespace DiveCompMVC.Controllers
{
    public class EventTypeController : Controller
    {
        public IActionResult Index() {
            return View();
        }
        [HttpPost]
        public IActionResult AddEventType()
    }
}
