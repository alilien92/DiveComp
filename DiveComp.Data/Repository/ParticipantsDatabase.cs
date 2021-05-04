using DiveComp.Data.Interfaces;
using DiveComp.Data.Models;
using DiveComp.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Pomelo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;
using DiveComp.Data.Helpers;

namespace DiveComp.Data.Repository
{
    public class ParticipantsDatabase : IParticipantRepo
    {
        private ModelContext db;

        public ParticipantsDatabase(ModelContext _db)
        {
            this.db = _db;
        }
        public bool CreateNewParticipant(EventsModel evt, DiverModel diver)
        {
            ParticipantsModel entry = new ParticipantsModel();
            entry.Event = evt; //Foreign key
            entry.Diver = diver;    //Foreign key
            entry.Score = 0;
            db.participants.Add(entry);
            db.SaveChanges();
            if(db.participants.Contains(entry))
            {
                return true;
            }
            return false;
        }

        public bool UpdateScore(int diverId, float newscore)
        {
            ParticipantsModel entry = db.participants.FirstOrDefault(x => x.diverId == diverId);

            entry.Score = newscore;
            if(entry.Score == newscore)
            {
                
                return true;
            }
            return false;
        }

        public List<LeaderBoardModel> GetAllParticipants(int eventid)
        {
            ProcedureHelper procedure = new ProcedureHelper(db);
            return procedure.spGetAllDivers(eventid);

        }

        public ParticipantsModel Get1Participant(int diverid)
        {
            return db.participants.FirstOrDefault(x => x.diverId == diverid);
        }

        public bool DeleteParticipant(int id)
        {
            db.participants.Remove(Get1Participant(id));
            db.SaveChanges();
            if(db.participants.Contains(Get1Participant(id)))
            {
                return false;
            }
            return true;
        }

        
    }
}
