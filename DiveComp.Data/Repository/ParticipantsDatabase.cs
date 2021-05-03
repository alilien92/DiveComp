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
        public bool CreateNewParticipant(ContestModel contest, DiverModel diver)
        {
            ParticipantsModel entry = new ParticipantsModel();
            entry.Contest = contest; //Foreign key
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
            db.participants.FirstOrDefault(x => x.diverId == diverId).Score += newscore;
            db.SaveChanges();
            ParticipantsModel entry = db.participants.FirstOrDefault(x => x.diverId == diverId);
            if(entry.Score == newscore)
            {
                return true;
            }
            return false;
        }

        public List<DiverBoardModel> GetAllParticipants(int contestid)
        {
            ProcedureHelper procedure = new ProcedureHelper(db);
            return procedure.spGetAllDivers(contestid);

        }

        
    }
}
