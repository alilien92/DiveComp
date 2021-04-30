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

        public bool CreateDiver(ClubModel club)
        {
            DiverModel entry = new DiverModel();
            entry.Club = club;
            db.divers.Add(entry);
            db.SaveChanges();
            if(db.divers.Contains(entry))
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
