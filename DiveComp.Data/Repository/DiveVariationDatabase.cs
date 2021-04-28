using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DiveComp.Data.Repository
{
    public class DiveVariationDatabase : IDiveVariationRepository
    {
        private ModelContext db;

        
        public DiveVariationDatabase(ModelContext _db) {
            this.db = _db;
        }

        public List<DiveVariationModel> GetAllDiveVariation() {
            return db.diveVariations.ToList();
        }

        public DiveVariationModel Get1DiveVariation(int id) {
            return db.diveVariations.FirstOrDefault(x => x.Id == id);
        }

        public bool AddDiveVariation(DiveVariationModel newDiveVariation) {
            
            db.diveVariations.Add(newDiveVariation);
            db.SaveChanges();
            return true;
        }

        public bool RemoveDiveVariation(int id) {
            var diveVariation = Get1DiveVariation(id);
            if (diveVariation == null) {
                return false;
            }
            db.diveVariations.Remove(diveVariation);
            db.SaveChanges();
            return true;
        }

        public List<DiveVariationModel> UpdateDiveVariation(int id, DiveVariationModel updatedDiveVariation) {
            if (this.RemoveDiveVariation(id)) {
                this.AddDiveVariation(updatedDiveVariation);
                db.SaveChanges();
                return db.diveVariations.ToList();
            }
            return db.diveVariations.ToList();
        }
    }
}
