using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace DiveComp.Data.Repository
{
    public class DiverDatabase : IDiverRepository
    {
        //database context
        private ModelContext db;

        

        public DiverDatabase(ModelContext _db)
        {
            this.db = _db;
        }

        
        public List<DiveModel> GetAllDivers()
        {
            return db.divers.ToList();
        }

        public DiveModel Get1Diver(int id)
        {
            return db.divers.FirstOrDefault(x => x.Id == id);
        }

        public bool AddDiver(DiveModel newDiver)
        {
            db.divers.Add(newDiver);
            db.SaveChanges();
            return true;
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
        public List<DiveModel> UpdateDiver(int id, DiveModel updatedDiver)
        {
            if (this.RemoveDiver(id))
            {
                this.AddDiver(updatedDiver);
                db.SaveChanges();
                return db.divers.ToList();
            }
            return db.divers.ToList();
        }

    }
}
