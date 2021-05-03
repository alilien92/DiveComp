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

        //GetCurrentDiverList procedure, returns a list of all divers in current contest id.
        public List<DiverBoardModel> spGetAllDivers(int contestid)
        {
            List<DiverBoardModel> diverlist = new List<DiverBoardModel>();

            using (MySqlConnection conn = new MySqlConnection(db.Database.GetDbConnection().ConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "GetCurrentDiverList"; // The name of the Stored Proc
                    cmd.CommandType = CommandType.StoredProcedure; // It is a Stored Proc

                    cmd.Parameters.AddWithValue("@Id", contestid);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            diverlist.Add(new DiverBoardModel()
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

    }
}

      
