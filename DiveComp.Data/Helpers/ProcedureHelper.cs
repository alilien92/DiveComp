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
        public List<LeaderBoardModel> spGetAllDivers(int eventid)
        {
            List<LeaderBoardModel> diverlist = new List<LeaderBoardModel>();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetCurrentDiverList"; // The name of the Stored Procedure
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
        public int spGetContestId(string name, string club) {

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
        public int spGetEventId(string name, int id) {

            EventsModel emodel = new EventsModel();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString)) {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand()) {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetEventId"; // The name of the Stored Procedure
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Procedure

                    cmd.Parameters.AddWithValue("@eventname", name);
                    cmd.Parameters.AddWithValue("@cid", id);

                    using (var reader = cmd.ExecuteReader()) {
                        while (reader.Read()) {
                            emodel.Id = (int)reader["Id"];
                        }
                    }
                }
            }

            return emodel.Id;
        }



    }
}

      
