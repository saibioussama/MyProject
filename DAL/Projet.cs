using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
     public class Projet
    {
        public string CodeP { get; set; }
        public string NomP { get; set; }

        public static List<Projet> Projets()
        {
            List<Projet> AllProjets = new List<Projet>();
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "GetAllProjets";
                MySqlDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    Projet p = new Projet()
                    {
                        CodeP = (string)reader[0],
                        NomP = (string)reader[1]
                    };
                    AllProjets.Add(p);
                }
                db.Connection.Close();
            }
            catch 
            {

            }

            return AllProjets;
        }

        public static Projet GetProjet(string Code)
        {
            Projet projet = new Projet();
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "GetOneProjet";
                db.Command.Parameters.AddWithValue("_CodeP",Code);
                MySqlDataReader reader = db.Command.ExecuteReader();
                reader.Read();
                projet.CodeP = (string)reader[0];
                projet.NomP = (string)reader[1];

                db.Connection.Close();
            }
            catch 
            {
                
            }
            return projet;
        }

        public static void InsertProjet(Projet projet)
        {
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "InsertProjet";
                db.Command.Parameters.AddWithValue("_CodeP", projet.CodeP);
                db.Command.Parameters.AddWithValue("_NomP", projet.NomP);
                db.Command.ExecuteNonQuery();
                db.Connection.Close();
            }
            catch 
            {
                
            }
        }

        public static void DeleteProjet(string Code)
        {
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "DeleteProjet";
                db.Command.Parameters.AddWithValue("_CodeP", Code);
                db.Command.ExecuteNonQuery();
                db.Connection.Close();
            }
            catch 
            {
                
            }
        }

        public static void UpdateProjet(Projet projet)
        {
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "UpdateProjet";
                db.Command.Parameters.AddWithValue("_CodeP", projet.CodeP);
                db.Command.Parameters.AddWithValue("_NomP", projet.NomP);
                db.Command.ExecuteNonQuery();
                db.Connection.Close();
            }
            catch 
            {
                
            }
        }
    }
}
