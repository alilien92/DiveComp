using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public DiverModel Get1Diver(int id)
        {
            return db.divers.FirstOrDefault(x => x.Id == id);
        }
    }
}
