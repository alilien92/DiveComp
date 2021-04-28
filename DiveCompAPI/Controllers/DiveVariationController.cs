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
    public class DiveVariationController : ControllerBase
    {
        private IDiveVariationRepository diveVariation;

        public DiveVariationController(IDiveVariationRepository _diveVariation) {
            this.diveVariation = _diveVariation;
        }

        [HttpGet("{id}")]
        public ActionResult<DiveVariationModel> GetDiveVariation(int id) {
            var diveVariations = diveVariation.Get1DiveVariation(id);
            if (diveVariations == null) {
                return NotFound();
            }
            return diveVariations;
        }

        [HttpPost]
        public ActionResult<DiveVariationModel> PostDiveVariation(DiveVariationModel diveVariations) {
            if (diveVariation.AddDiveVariation(diveVariations)) {
                return diveVariations;
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<List<DiveVariationModel>> DeleteDiveVariation(int id) {
            if (diveVariation.RemoveDiveVariation(id)) {
                return diveVariation.GetAllDiveVariation();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<DiveVariationModel>> UpdateDiver(int id, DiveVariationModel updatedDiveVariation) {
            var diveVariations = diveVariation.UpdateDiveVariation(id, updatedDiveVariation);
            if (diveVariations != null) {
                return diveVariations;
            }
            return NotFound();
        }

        [HttpGet]
        public ActionResult<List<DiveVariationModel>> GetAllDiveVariation() {
            return diveVariation.GetAllDiveVariation();
        }
    }
}
