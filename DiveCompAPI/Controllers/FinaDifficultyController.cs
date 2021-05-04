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
        public class FinaDifficultyController : ControllerBase
        {
            private IFinaDifficultyRepo finaDifficulty;

            public FinaDifficultyController(IFinaDifficultyRepo _finaDifficulty) {
                this.finaDifficulty = _finaDifficulty;
            }

            [HttpGet("{id}")]
            public ActionResult<FinaDifficultyModel> GetFinaDifficulty(int id) {
                var finaDifficultys = finaDifficulty.Get1Difficulty(id);
                if (finaDifficultys == null) {
                    return NotFound();
                }
                return finaDifficultys;
            }

            [HttpPost]
            public ActionResult<FinaDifficultyModel> PostFinaDifficulty(List<FinaDifficultyModel> finaDifficultys) {
            if (finaDifficultys.Count >= 2) {
                for (int i = 0; i < finaDifficultys.Count; i++) {
                    FinaDifficultyModel item = finaDifficultys[i];
                    finaDifficulty.AddFinaDifficulty(item);
                }
                return Ok();
            }
            
                return BadRequest();
            }

            [HttpDelete("{id}")]
            public ActionResult<List<FinaDifficultyModel>> DeleteFinaDifficulty(int id) {
                if (finaDifficulty.RemoveFinaDifficulty(id)) {
                    return finaDifficulty.GetAllFinaDifficulty();
                }
                return NotFound();
            }

            [HttpPut("{id}")]
            public ActionResult<IEnumerable<FinaDifficultyModel>> UpdateDiver(int id, FinaDifficultyModel updatedFinaDifficulty) {
                var finaDifficultys = finaDifficulty.UpdateFinaDifficulty(id, updatedFinaDifficulty);
                if (finaDifficultys != null) {
                    return finaDifficultys;
                }

                return NotFound();
            }

            [HttpGet]
            public ActionResult<List<FinaDifficultyModel>> GetAllFinaDifficulty() {
                return finaDifficulty.GetAllFinaDifficulty();
            }
        }
    
}
