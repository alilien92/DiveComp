using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DiveComp.Data.Repository
{
    public class JudgeDatabase : IJudgeRepo
    {
        private ModelContext db;

        public JudgeDatabase(ModelContext _db)
        {
            this.db = _db;
        }
        public List<JudgeModel> GetAllJudges()
        {
            return db.judges.ToList();
        }

        public JudgeModel Get1Judge(int id)
        {
            return db.judges.FirstOrDefault(x => x.Id == id);
        }

        public bool AddJudge(JudgeModel newJudge)
        {
            db.judges.Add(newJudge);
            db.SaveChanges();
            return true;
        }

        public bool RemoveJudge(int id)
        {
            var judge = Get1Judge(id);
            if(judge == null)
            {
                return false;
            }
            db.judges.Remove(judge);
            db.SaveChanges();
            return true;
        }

        public List<JudgeModel> UpdateJudge(int id, JudgeModel updatedJudge)
        {
            if (this.RemoveJudge(id))
            {
                this.AddJudge(updatedJudge);
                db.SaveChanges();
                return db.judges.ToList();
            }
            return db.judges.ToList();
        }
    }
}
