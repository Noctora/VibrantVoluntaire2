using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using VibrantVoluntaire2.Models;

namespace VibrantVoluntaire2.Data
{
    internal class NGODAO
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=VV2Db;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //performs all operations on the database. get all, create, delete, get one, search etc.

        public List<NGOAcc> FetchAll()
        {
            //To list down everything in NGOAcc
            List<NGOAcc> returnList = new List<NGOAcc>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.NGO_Info";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NGOAcc ngo = new NGOAcc();
                        ngo.NGOId = reader.GetInt32(0);
                        ngo.NGOname = reader.GetString(1);
                        ngo.vision = reader.GetString(2);
                        ngo.mission = reader.GetString(3);
                        ngo.objective = reader.GetString(4);
                        ngo.HQlocation = reader.GetString(5);
                        ngo.status = reader.GetString(6);
                        ngo.websiteaddress = reader.GetString(7);
                        ngo.emailaddress = reader.GetString(8);
                        ngo.establisheddate = reader.GetString(9);
                        ngo.SMlink = reader.GetString(10);

                        returnList.Add(ngo);
                    }
                }
            }
            return returnList;

        }

        


        //instead of list, we just gonna use a single NGOAcc object
        public NGOAcc FetchOne(int id)
        {

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.NGO_Info WHERE NGOId = @id";

                // associate @id with Id parameter beside fetchone


                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                NGOAcc ngo = new NGOAcc();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        ngo.NGOId = reader.GetInt32(0);
                        ngo.NGOname = reader.GetString(1);
                        ngo.vision = reader.GetString(2);
                        ngo.mission = reader.GetString(3);
                        ngo.objective = reader.GetString(4);
                        ngo.HQlocation = reader.GetString(5);
                        ngo.status = reader.GetString(6);
                        ngo.websiteaddress = reader.GetString(7);
                        ngo.emailaddress = reader.GetString(8);
                        ngo.establisheddate = reader.GetString(9);
                        ngo.SMlink = reader.GetString(10);


                    }
                }
                return ngo;
            }


        }

        

        // create new
        public int CreateOrUpdate(NGOAcc ngoAcc)
        {
            // if NGOAcc.ngoid <= 1 then create

            // if NGOAcc.ngoid > 1 then update is meant


            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "";

                if (ngoAcc.NGOId <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.NGO_Info Values(@NGOname,@vision,@mission,@objective,@HQlocation,@status,@websiteaddress,@emailaddress,@establisheddate,@SMlink)";
                }
                else
                {
                    //update
                    sqlQuery = "UPDATE dbo.NGO_Info SET NGOname = @NGOname, vision = @vision, mission = @mission, objective = @objective, HQlocation = @HQlocation, status = @status, websiteaddress = @websiteaddress, emailaddress = @emailaddress, establisheddate = @establisheddate, SMlink = @SMlink WHERE NGOId = @NGOId";
                }

                // associate @id with Id parameter beside fetchone
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@NGOId", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.NGOId;
                command.Parameters.Add("@NGOname", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.NGOname;
                command.Parameters.Add("@vision", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.vision;
                command.Parameters.Add("@mission", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.mission;
                command.Parameters.Add("@objective", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.objective;
                command.Parameters.Add("@HQlocation", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.HQlocation;
                command.Parameters.Add("@status", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.status;
                command.Parameters.Add("@websiteaddress", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.websiteaddress;
                command.Parameters.Add("@emailaddress", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.emailaddress;
                command.Parameters.Add("@establisheddate", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.establisheddate;
                command.Parameters.Add("@SMlink", System.Data.SqlDbType.VarChar, 1000).Value = ngoAcc.SMlink;

                connection.Open();

                //Doing an inserting
                int newID = command.ExecuteNonQuery();

                

                
                return newID;
            }


        }

        // delete one
        internal int  Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "DELETE FROM dbo.NGO_Info WHERE NGOId = @NGOId";
              
                // associate @id with Id parameter beside fetchone
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@NGOId", System.Data.SqlDbType.VarChar, 1000).Value = id;
                
                connection.Open();

                //Doing an inserting
                int deleteID = command.ExecuteNonQuery();

                return deleteID;
            }
        }

        // update one

        // search for name
        internal List<NGOAcc> SearchForName(string searchPhrase)
        {
            //To list down everything in NGOAcc
            List<NGOAcc> returnList = new List<NGOAcc>();

            // access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.NGO_Info WHERE NGOname LIKE @searchForMe";
               
                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        NGOAcc ngo = new NGOAcc();
                        ngo.NGOId = reader.GetInt32(0);
                        ngo.NGOname = reader.GetString(1);
                        ngo.vision = reader.GetString(2);
                        ngo.mission = reader.GetString(3);
                        ngo.objective = reader.GetString(4);
                        ngo.HQlocation = reader.GetString(5);
                        ngo.status = reader.GetString(6);
                        ngo.websiteaddress = reader.GetString(7);
                        ngo.emailaddress = reader.GetString(8);
                        ngo.establisheddate = reader.GetString(9);
                        ngo.SMlink = reader.GetString(10);

                        returnList.Add(ngo);
                    }
                }
            }
            return returnList;
        }
        // search for location
    }
}