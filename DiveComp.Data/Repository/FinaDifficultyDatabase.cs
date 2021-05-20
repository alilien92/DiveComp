using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
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

        public void InsertFinaTable()
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
        }

        public float DetermineDiveType(string type, float height, int dcn)
        {
            ProcedureHelper entry = new ProcedureHelper(db);
            if (type == "STR")
            {
                return entry.spGetDiffModSTR(height, dcn);
            }
            if (type == "Pike")
            {
                return entry.spGetDiffModPike(height, dcn);
            }
            if (type == "Tuck")
            {
                return entry.spGetDiffModTuck(height, dcn);
            }
            if (type == "Free")
            {
                return entry.spGetDiffModFree(height, dcn);
            }
            return height;
        }
    }
}

