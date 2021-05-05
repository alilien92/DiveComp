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
            //Lagrad Procedur: Hämta specifik difficulty
            public ActionResult<FinaDifficultyModel> GetFinaDifficulty(int id) {
                throw new NotImplementedException();
            }

        [HttpGet("dives/{height}")]
        public ActionResult<List<FinaDifficultyModel>> GetDivesFromHeight(float height)
        {
            var divelist = finaDifficulty.GetHeightDifficulty(height);
            if(divelist != null)
            {
                return divelist;
            }
            return NotFound();
        }
        

        [HttpPost]
            public ActionResult<FinaDifficultyModel> PostFinaDifficulty()
            {
                if(finaDifficulty.InsertFinaTable())
                {
                return Ok();
                }
                return BadRequest();
                
            }
        }
    
}
