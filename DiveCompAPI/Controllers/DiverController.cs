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
    public class DiverController : ControllerBase
    {
        private IDiverRepository divers;

        public DiverController(IDiverRepository _divers)
        {
            this.divers = _divers;
        }

        [HttpGet("{id}")]
        public ActionResult<DiveModel> GetDiver(int id)
        {
            var diver = divers.Get1Diver(id);
            if (diver == null)
            {
                return NotFound();
            }
            return diver;
        }

        [HttpPost]
        public ActionResult<DiveModel> PostDiver(DiveModel diver)
        {
            if (divers.AddDiver(diver))
            {
                return diver;
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<List<DiveModel>> DeleteDiver(int id)
        {
            if (divers.RemoveDiver(id))
            {
                return divers.GetAllDivers();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<DiveModel>> UpdateDiver(int id, DiveModel updatedDiver)
        {
            var diver = divers.UpdateDiver(id, updatedDiver);
            if (diver != null)
            {
                return diver;
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<List<DiveModel>> GetAllDivers()
        {
            return divers.GetAllDivers();
        }


    }
}
