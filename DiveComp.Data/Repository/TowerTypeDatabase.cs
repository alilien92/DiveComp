using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DiveComp.Data.Repository
{
    public class TowerTypeDatabase : ITowerRepo
    {
        private ModelContext db;

        public TowerTypeDatabase(ModelContext _db)
        {
            this.db = _db;
        }
        public List<TowerTypeModel> GetAllTowers()
        {
            return db.Towers.ToList();
        }

        public TowerTypeModel Get1Tower(int id)
        {
            return db.Towers.FirstOrDefault(x => x.Id == id);
        }

        public bool AddTower(TowerTypeModel newTower)
        {
            db.Towers.Add(newTower);
            db.SaveChanges();
            return true;
        }

        public bool RemoveTower(int id)
        {
            var Tower = Get1Tower(id);
            if (Tower == null)
            {
                return false;
            }
            db.Towers.Remove(Tower);
            db.SaveChanges();
            return true;
        }

        public List<TowerTypeModel> UpdateTower(int id, TowerTypeModel updatedTower)
        {
            if (this.RemoveTower(id))
            {
                this.AddTower(updatedTower);
                db.SaveChanges();
                return db.Towers.ToList();
            }
            return db.Towers.ToList();
        }
    }
}
