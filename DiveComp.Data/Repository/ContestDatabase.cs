using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
    }
}
