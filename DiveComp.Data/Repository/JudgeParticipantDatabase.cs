using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using DiveComp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DiveComp.Data.Repository
{
    public class JudgeParticipantDatabase : IJudgeParticipantRepo
    {
        private ModelContext db;

        public JudgeParticipantDatabase(ModelContext _db)
        {
            this.db = _db;
        }
        public bool CreateNewJudgeParticipant(ContestModel contest, JudgeModel judge)
        {
            JudgeParticipantModel entry = new JudgeParticipantModel();
            entry.Contest = contest; //Foreign key
            entry.Judge = judge;    //Foreign key
            db.judgeParticipant.Add(entry);
            db.SaveChanges();
            if (db.judgeParticipant.Contains(entry))
            {
                return true;
            }
            return false;
        }

        public JudgeParticipantModel Get1JudgeParticipant(int id)
        {
            return db.judgeParticipant.FirstOrDefault(x => x.ContestId == id);
        }
    }
}
