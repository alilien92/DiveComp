using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiveComp.Data.Repository
{
    class ClubDatabase
    {
        private ModelContext db;

        public ClubDatabase(ModelContext _db)
        {
            this.db = _db;
        }
        public List<ClubModel> GetAllClubs()
        {
            return db.clubs.ToList();
        }

        public ClubModel Get1Club(int id)
        {
            return db.clubs.FirstOrDefault(x => x.Id == id);
        }

        public bool AddClub(ClubModel newClub)
        {
            db.clubs.Add(newClub);
            db.SaveChanges();
            return true;
        }

        public bool RemoveClub(int id)
        {
            var club = Get1Club(id);
            if (club == null)
            {
                return false;
            }
            db.clubs.Remove(club);
            db.SaveChanges();
            return true;
        }

        public List<ClubModel> UpdateClub(int id, ClubModel updatedClub)
        {
            if (this.RemoveClub(id))
            {
                this.AddClub(updatedClub);
                db.SaveChanges();
                return db.clubs.ToList();
            }
            return db.clubs.ToList();
        }
    }
}
