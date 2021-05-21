using Microsoft.AspNetCore.Mvc;
using DiveCompMVC.Models;
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

        public IActionResult Index()
        {
            ViewModel vm = new ViewModel();
            vm.AllDivers = divers.GetAllDivers();
            return View(vm);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DiverModel model) 
        {
            if (ModelState.IsValid) 
            {
                divers.CreateDiver(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

