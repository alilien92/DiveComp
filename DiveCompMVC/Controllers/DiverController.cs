using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiveComp.Data.Models;
using System.Net.Http;
using DiveComp.Data.Interfaces;

namespace DiveCompMVC.Controllers
{
    public class DiverController : Controller
    {
        private IDiverRepo divers;


        public DiverController(IDiverRepo _divers) {
            this.divers = _divers;
        }
        
        public IActionResult AddDiver() {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddDiver(DiverModel model) {
            if (ModelState.IsValid) {
                divers.CreateDiver(model);
                return View();
            }
                return View();
            }
        }
    }

