using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Departement
    {
        public int NumDept { get; set; }
        public string NomDept { get; set; }
        public string Lieu { get; set; }
        


        public static List<Departement> Departements()
        {
            List<Departement> AllDep = new List<Departement>();
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "GetAllDepartements";
                MySqlDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    Departement d = new Departement();
                    if (reader.IsDBNull(0))
                        d.NumDept = 0;
                    else
                        d.NumDept = (int)reader["NumDept"];
                    if (reader.IsDBNull(1))
                        d.NomDept = null;
                    else
                        d.NomDept = (string)reader["NomDept"];
                    if (reader.IsDBNull(2))
                        d.Lieu = null;
                    else
                        d.Lieu = (string)reader["Lieu"];

                    AllDep.Add(d);
                }

                db.Connection.Close();
            }
            catch
            {

            }

            return AllDep;
        }

        public static Departement GetDepartement(int id)
        {
            Departement departement = new Departement();

            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "GetOneDepartement";
                db.Command.Parameters.AddWithValue("_NumDept",id);
                MySqlDataReader reader = db.Command.ExecuteReader();
                reader.Read();
                departement.NumDept = (int)reader[0];
                departement.NomDept = (string)reader[1];
                departement.Lieu = (string)reader[2];
                db.Connection.Close();
            }
            catch 
            {
                
            }

            return departement;
        }

        public static void InsertDepartement(Departement departement)
        {
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "InsertDepartement";
                db.Command.Parameters.AddWithValue("_NumDept", departement.NumDept);
                db.Command.Parameters.AddWithValue("_NomDept", departement.NomDept);
                db.Command.Parameters.AddWithValue("_Lieu", departement.Lieu);
                db.Command.ExecuteNonQuery();
                db.Connection.Close();
            }
            catch  
            {
                   
            }
        }

        public static void DeleteDepartement(int id)
        {
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "DeleteDepartement";
                db.Command.Parameters.AddWithValue("_NumDept", id);
                db.Command.ExecuteNonQuery();
                db.Connection.Close();
            }
            catch 
            {

                throw;
            }
        }

        public static void UpdateDepatement(Departement departement)
        {
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "UpdateDepartement";
                db.Command.Parameters.AddWithValue("_NumDept", departement.NumDept);
                db.Command.Parameters.AddWithValue("_NomDept", departement.NomDept);
                db.Command.Parameters.AddWithValue("_Lieu", departement.Lieu);
                db.Command.ExecuteNonQuery();
                db.Connection.Close();
            }
            catch 
            {

            }
        }

    }
}
