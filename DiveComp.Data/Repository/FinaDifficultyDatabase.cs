using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DiveComp.Data.Helpers;
namespace DiveComp.Data.Repository
{
    public class FinaDifficultyDatabase : IFinaDifficultyRepo
    {
        private ModelContext db;


        public FinaDifficultyDatabase(ModelContext _db) {
            this.db = _db;
        }

        public List<FinaDifficultyModel> GetAllFinaDifficulty() {
            return db.difficultyMods.ToList();
        }

        public FinaDifficultyModel Get1Difficulty(int id) {
            return db.difficultyMods.FirstOrDefault(x => x.Id == id);
        }
        
        public List<FinaDifficultyModel> GetHeightDifficulty(float height) {
            var pHelper = new ProcedureHelper(db);

            return pHelper.spGetAllDifficulties(height);
        }

        public bool AddFinaDifficulty(FinaDifficultyModel newDifficulty) {

            db.difficultyMods.Add(newDifficulty);
            db.SaveChanges();
            return true;
        }

        public bool RemoveFinaDifficulty(int id) {
            var dMod = Get1Difficulty(id);
            if (dMod == null) {
                return false;
            }
            db.difficultyMods.Remove(dMod);
            db.SaveChanges();
            return true;
        }

        public List<FinaDifficultyModel> UpdateFinaDifficulty(int id, FinaDifficultyModel updatedFinaDifficulty) {
            if (this.RemoveFinaDifficulty(id)) {
                this.AddFinaDifficulty(updatedFinaDifficulty);
                db.SaveChanges();
                return db.difficultyMods.ToList();
            }
            return db.difficultyMods.ToList();
        }
    }
}

