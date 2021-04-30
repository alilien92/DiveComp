using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using DiveComp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DiveComp.Data.Repository
{
    public class ParticipantsDatabase : IParticipantsRepo
    {
        private ModelContext db;

        public ParticipantsDatabase(ModelContext _db)
        {
            this.db = _db;
        }
        public bool CreateNewParticipant(ContestModel contest, DiverModel diver)
        {
            ParticipantsModel entry = new ParticipantsModel();
            entry.Contest = contest; //Foreign key
            entry.Diver = diver;    //Foreign key
            entry.Score = null;
            db.participants.Add(entry);
            db.SaveChanges();
            if(db.participants.Contains(entry))
            {
                return true;
            }
            return false;
        }

        public ParticipantsModel Get1Participant(int id)
        {
            return db.participants.FirstOrDefault(x => x.contestId == id);
        }

        
    }
}
