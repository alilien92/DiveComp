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

    public class TowerController : ControllerBase
    {

        private ITowerRepo Towers;

        public TowerController(ITowerRepo _Towers)
        {
            this.Towers = _Towers;
        }

        [HttpGet]
        public ActionResult<List<TowerTypeModel>> GetAllTowers()
        {
            return Towers.GetAllTowers();
        }

        [HttpGet("{id}")]
        public ActionResult<TowerTypeModel> GetTower(int id)
        {
            var Tower = Towers.Get1Tower(id);
            if (Tower == null)
            {
                return NotFound();
            }
            return Tower;
        }

        [HttpPost]
        public ActionResult<TowerTypeModel> PostTower(TowerTypeModel Tower)
        {
            if (Towers.AddTower(Tower))
            {
                return Tower;
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<List<TowerTypeModel>> DeleteTower(int id)
        {
            if (Towers.RemoveTower(id))
            {
                return Towers.GetAllTowers();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<TowerTypeModel>> UpdateTower(int id, TowerTypeModel updatedTower)
        {
            var Tower = Towers.UpdateTower(id, updatedTower);
            if (Tower != null)
            {
                return Tower;
            }
            return NotFound();
        }
    }
}