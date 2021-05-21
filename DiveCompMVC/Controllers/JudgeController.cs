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
    public class JudgeController : Controller
    {
        private IJudgeRepo judges;



        public JudgeController(IJudgeRepo _judges)
        {
            this.judges = _judges;
        }

        public IActionResult Index()
        {
            ViewModel vm = new ViewModel();
            vm.AllJudges = judges.GetAllJudges();
            return View(vm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(JudgeModel model)
        {
            if (ModelState.IsValid)
            {
                judges.AddJudge(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
