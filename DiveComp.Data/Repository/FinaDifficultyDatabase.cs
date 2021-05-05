using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

using DiveComp.Data.Helpers;
namespace DiveComp.Data.Repository
{
    public class FinaDifficultyDatabase : IFinaDifficultyRepo
    {
        private ModelContext db;

        public FinaDifficultyDatabase(ModelContext _db) {
            this.db = _db;
        }

        public FinaDifficultyModel Get1Difficulty(int id) {
            //Kalla lagrad procedur
            throw new NotImplementedException();
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

        public bool InsertFinaTable()
        {
            var finaList = new List<FinaDifficultyModel>();

            using (StreamReader r = new StreamReader(@"C:\Users\pontu\Desktop\SoP\DiveComp\DiveComp.Data\Helpers\FinaTable.json"))
            {
                string json = r.ReadToEnd();
                finaList = JsonConvert.DeserializeObject<List<FinaDifficultyModel>>(json);
            }

            foreach (var diveobject in finaList)
                db.Add(diveobject);

            db.SaveChanges();
            return true;
        }
    }
}

