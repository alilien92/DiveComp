using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using DiveComp.Data.Repository;
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
    public class DiverController : ControllerBase
    {
        private IDiverRepo divers;


        public DiverController(IDiverRepo _divers)
        {
            this.divers = _divers;
        }

        [HttpPost]
        public ActionResult<DiverModel> PostDiver(DiverModel diver)
        {

            if (divers.CreateDiver(diver))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<DiverModel> GetDiver(int id)
        {
            DiverModel diver = divers.Get1Diver(id);
            if(diver != null)
            {
                return diver;
            }
            return NotFound();
        }

    }
}
