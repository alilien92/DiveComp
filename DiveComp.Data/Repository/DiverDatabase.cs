using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DiveComp.Data.Helpers;

namespace DiveComp.Data.Repository
{
    public class DiverDatabase : IDiverRepo
    {
        private ModelContext db;

        public DiverDatabase(ModelContext _db)
        {
            this.db = _db;
        }

        public bool CreateDiver(DiverModel diver)
        {
            
            db.divers.Add(diver);
            db.SaveChanges();
            if(db.divers.Contains(diver))
            {
                return true;
            }
            return false;
        }

        public bool RemoveDiver(int id)
        {
            var diver = Get1Diver(id);
            if (diver == null)
            {
                return false;
            }
            db.divers.Remove(diver);
            db.SaveChanges();
            return true;
        }

        public List<DiverModel> GetAllDivers()
        {
            return db.divers.ToList();
        }

        public DiverModel Get1Diver(int id)
        {
            return db.divers.FirstOrDefault(x => x.Id == id);
        }

        public List<DiverModel> GetDiverListByContest(int id)
        {
            ProcedureHelper entry = new ProcedureHelper(db);
            return entry.spGetDiverListByContest(id);
        }

        public List<DiverModel> GetDiversNotInContest(int id)
        {
            ProcedureHelper entry = new ProcedureHelper(db);
            return entry.spGetDiversNotInContest(id);
        }
    }
}
