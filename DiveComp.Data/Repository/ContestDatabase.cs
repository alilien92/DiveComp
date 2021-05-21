using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DiveComp.Data.Helpers;

namespace DiveComp.Data.Repository
{
    public class ContestDatabase : IContestRepo
    {
        private ModelContext db;

        public ContestDatabase(ModelContext _db)
        {
            this.db = _db;
        }
        public bool CreateNewContest(ContestModel contest)
        {
            
            db.contests.Add(contest);
            db.SaveChanges();
            if (db.contests.Contains(contest))
            {
                return true;
            }
            return false;
        }

        public ContestModel Get1Contest(int id)
        {
            return db.contests.FirstOrDefault(x => x.Id == id);
        }

        public ActiveContest GetActiveContest(int id)
        {
            ProcedureHelper entry = new ProcedureHelper(db);
            ActiveContest contest = new ActiveContest();
            contest.contest = Get1Contest(id);
            contest.contest.Type = entry.spGetEventType(contest.contest.TypeId);
            contest.divers = entry.spGetDiverListByContest(id);
            contest.judges = entry.spGetJudgeByContestId(id);
            contest.leaderboard = entry.spGetLeaderboardByContest(id);
            return contest;
        }
       
        public int GetContestId(string name, string club) {
            ProcedureHelper ph = new ProcedureHelper(db);
            return ph.spGetContestId(name, club);
        }

        public List<ContestModel> GetAllContests()
        {
            ProcedureHelper entry = new ProcedureHelper(db);
            List<ContestModel> existingContests = db.contests.OrderBy(x => x.Date).ToList();
            
            foreach(var item in existingContests)
            {
               
                item.Type = entry.spGetEventType(item.TypeId);
            }

            return existingContests;
        }
    }
}
