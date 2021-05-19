using System;
using System.Collections.Generic;
using System.Text;
using DiveComp.Data.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System.Data;

namespace DiveComp.Data.Helpers
{
    //Class for Stored Procedures
    public class ProcedureHelper
    {
        private ModelContext db;

        public ProcedureHelper(ModelContext _db)
        {
            this.db = _db;
        }

        //GetCurrentDiverList procedure, returns a list of all divers and their score with given contest id.
        public List<LeaderBoardModel> spGetLeaderboardByEvent(int eventid)
        {
            List<LeaderBoardModel> diverlist = new List<LeaderBoardModel>();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetLeaderboardByEvent"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure

                    cmd.Parameters.AddWithValue("@Id", eventid);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            diverlist.Add(new LeaderBoardModel()
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Club = reader["Club"].ToString(),
                                Score = (float)reader["Score"]
                            }); ;
                        }
                    }
                }
            }
            return diverlist;
        }

        public List<DiverModel> spGetDiverListByContest(int contestId)
        {
            List<DiverModel> diverlist = new List<DiverModel>();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetDiverListByContest"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure

                    cmd.Parameters.AddWithValue("@id", contestId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            diverlist.Add(new DiverModel()
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Club = reader["Club"].ToString(),
                                Country = reader["Country"].ToString()
                            }); ;
                        }
                    }
                }
            }
            return diverlist;
        }

        public List<FinaDifficultyModel> spGetAllDifficulties(float height) { 
            List<FinaDifficultyModel> difficultylist = new List<FinaDifficultyModel>();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString)) {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetDifficultyMod"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure

                    cmd.Parameters.AddWithValue("@H", height);

                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            difficultylist.Add(new FinaDifficultyModel() {
                                Id = (int)reader["Id"],
                                DiveCodeNumber = (int)reader["DiveCodeNumber"],
                                Height = (float)reader["Height"],
                                DiveVariation = reader["DiveVariation"].ToString(),
                                STR = (float)reader["STR"],
                                Pike = (float)reader["Pike"],
                                Tuck = (float)reader["Tuck"],
                                Free = (float)reader["Free"]
                            }); ;
                        }
                    }
                }
            }
            return difficultylist;
        }

        public void spUpdateScore(int diverid, float newscore)
        {

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UpdateScore"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure

                    cmd.Parameters.AddWithValue("@id", diverid);
                    cmd.Parameters.AddWithValue("@newscore", newscore);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public int spGetContestId(string name, string club) { // XXXX

            ContestModel cmodel = new ContestModel();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString)) {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetContestId"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure

                    cmd.Parameters.AddWithValue("@contestname", name);
                    cmd.Parameters.AddWithValue("@contestclub", club);
                    
                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                                cmodel.Id = (int)reader["Id"];    
                        }
                    }
                    }
                }
            
            return cmodel.Id;
        }

        public EventTypeModel spGetEventType(int id)
        {

            EventTypeModel emodel = new EventTypeModel();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetEventType"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure

                    cmd.Parameters.AddWithValue("@Typeid", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            emodel.Id = (int)reader["Id"];
                            emodel.Gender = reader["Gender"].ToString();
                            emodel.Type = reader["Type"].ToString();
                            emodel.Height = (float)reader["Height"];
                        }
                    }
                }
            }

            return emodel;
        }
        /*
        public List<EventsModel> spGetEvents(int contestid)
        {
            List<EventsModel> eventlist = new List<EventsModel>();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetEvents"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure

                    cmd.Parameters.AddWithValue("@cid", contestid);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            eventlist.Add(new EventsModel()
                            {
                                Id = (int)reader["Id"],
                                ContestId = (int)reader["ContestId"],
                                Type = spGetEventType((int)reader["TypeId"])
                            }); ;
                        }
                    }
                }
            }
            return eventlist;
        }
        */

        public List<EventTypeModel> spGetAllEventTypes() {
            List<EventTypeModel> eventTypeList = new List<EventTypeModel>();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString)) {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetAllEventTypes"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure
                    

                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            eventTypeList.Add(new EventTypeModel() {
                                Id = (int)reader["Id"],
                                Gender = reader["Gender"].ToString(),
                                Type = reader["Type"].ToString(),
                                Height = (float)reader["Height"]
                            }); ;
                        }
                    }
                }
            }
            return eventTypeList;
        }



        public List<JudgeModel> spGetJudgeByContestId(int contestid)
        {
            List<JudgeModel> resultlist = new List<JudgeModel>();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetJudgeByContestId"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure

                    cmd.Parameters.AddWithValue("@cid", contestid);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultlist.Add(new JudgeModel()
                            {
                                Id = (int)reader["Id"],
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Org = reader["Org"].ToString()
                            }); ;
                        }
                    }
                }
            }
            return resultlist;
        }

        /*
        public List<ActiveEventModel> spGetEventsForContest(int contestid)
        {
            List<ActiveEventModel> resultlist = new List<ActiveEventModel>();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetEventsForContest"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure

                    cmd.Parameters.AddWithValue("@id", contestid);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultlist.Add(new ActiveEventModel()
                            {
                                Id = (int)reader["Id"],
                                Type = spGetEventType((int)reader["TypeId"]),
                                diverlist = spGetDiverListByEvent((int)reader["Id"]),
                                leaderboard = spGetLeaderboardByEvent((int)reader["Id"])
                            }) ; ;
                        }
                    }
                }
            }
            return resultlist;
        }
        */

    }
}

      
