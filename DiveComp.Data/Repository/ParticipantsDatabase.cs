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
            entry.HasJumped = 0;
            db.participants.Add(entry);
            db.SaveChanges();
            if(db.participants.Contains(entry))
            {
                return true;
            }
            return false;
        }
        
        public void UpdateScore(int contestid, int diverId, float newScore)
        {
            ProcedureHelper procedure = new ProcedureHelper(db);
            procedure.spUpdateScore(contestid, diverId, newScore);
        }
        

        public List<LeaderBoardModel> GetAllParticipants(int contestId)
        {
            ProcedureHelper procedure = new ProcedureHelper(db);
            return procedure.spGetLeaderboardByContest(contestId);

        }

        public ParticipantsModel Get1Participant(int diverId)
        {
            return db.participants.FirstOrDefault(x => x.DiverId == diverId);
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


        

        /*
        public List<LeaderBoardModel> GetContestResult(int contestid)
        {
            ProcedureHelper procedure = new ProcedureHelper(db);
            return procedure.spGetContestResult(contestid);
        }
        */
    }
}
