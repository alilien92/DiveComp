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
    public class JudgeController : ControllerBase
    {

        private IJudgeRepository judges;

        public JudgeController(IJudgeRepository _judges)
        {
            this.judges = _judges;
        }

        [HttpGet]
        public ActionResult<List<JudgeModel>> GetAllJudges()
        {
            return judges.GetAllJudges();
        }

        [HttpGet("{id}")]
        public ActionResult<JudgeModel> GetJudge(int id)
        {
            var judge = judges.Get1Judge(id);
            if (judge == null)
            {
                return NotFound();
            }
            return judge;
        }

        [HttpPost]
        public ActionResult<JudgeModel> Postjudge(JudgeModel judge)
        {
            if (judges.AddJudge(judge))
            {
                return judge;
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public ActionResult<List<JudgeModel>> Deletejudge(int id)
        {
            if (judges.RemoveJudge(id))
            {
                return judges.GetAllJudges();
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult<IEnumerable<JudgeModel>> Updatejudge(int id, JudgeModel updatedJudge)
        {
            var judge = judges.UpdateJudge(id, updatedJudge);
            if (judge != null)
            {
                return judge;
            }
            return NotFound();
        }

        
    }
}
