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
    public class ClubController : ControllerBase
    {
        private IClubRepo clubs;

        public ClubController(IClubRepo _clubs)
        {
            this.clubs = _clubs;
        }

        [HttpGet]
        public ActionResult<List<ClubModel>> GetAllClubs()
        {
            return clubs.GetAllClubs();
        }

        [HttpGet("{id}")]
        public ActionResult<ClubModel> GetClub(int id)
        {
            var club = clubs.Get1Club(id);
            if (club == null)
            {
                return NotFound();
            }
            return club;
        }

        [HttpPost]
        public ActionResult<ClubModel> PostClub(ClubModel club)
        {
            if (clubs.AddClub(club))
            {
                return club;
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<List<ClubModel>> DeleteClub(int id)
        {
            if (clubs.RemoveClub(id))
            {
                return clubs.GetAllClubs();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<ClubModel>> UpdateClub(int id, ClubModel updatedClub)
        {
            var club = clubs.UpdateClub(id, updatedClub);
            if (club != null)
            {
                return club;
            }
            return NotFound();
        }
    }
}
