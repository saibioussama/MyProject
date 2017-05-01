using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Participation
    {
        public int Id { get; set; }
        public Employe _Employe { get; set; }
        public Projet _Projet { get; set; }
        public string Fonction { get; set; }

        public static List<Participation> Participations()
        {
            List<Participation> AllParticipation = new List<Participation>();

            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "GetAllParticipations";
                MySqlDataReader reader = db.Command.ExecuteReader();
                while(reader.Read())
                {
                    Participation p = new Participation()
                    {
                        Id = (int)reader[0],
                        _Employe = new Employe()
                    };
                    p._Employe = Employe.GetEmploye((int)reader[1]);
                    p._Projet = new Projet();
                    p._Projet = Projet.GetProjet((string)reader[2]);
                    p.Fonction = (string)reader[3];
                    AllParticipation.Add(p);
                }
                db.Connection.Close();
            }
            catch 
            {
                
            }

            return AllParticipation;
        }

        public static Participation GetParticipation(int _Id)
        {
            Participation participation = new Participation();

            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "GetOneParticipation";
                db.Command.Parameters.AddWithValue("_id", _Id);
                
                MySqlDataReader reader = db.Command.ExecuteReader();
                reader.Read();
                 
                participation.Id = (int)reader[0];
                participation._Employe = new Employe();
                participation._Employe = Employe.GetEmploye((int)reader[1]);
                participation._Projet = new Projet();
                participation._Projet = Projet.GetProjet((string)reader[2]);
                participation.Fonction = (string)reader[3];

                db.Connection.Close();
            }
            catch
            {

            }
            return participation;
        }

        public static void InsertParticipation(Participation particiation)
        {
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "InsertParticipation";
                db.Command.Parameters.AddWithValue("_Id", particiation.Id);
                db.Command.Parameters.AddWithValue("_Matr", particiation._Employe.Matr);
                db.Command.Parameters.AddWithValue("_CodeP", particiation._Projet.CodeP);
                db.Command.Parameters.AddWithValue("_Fonction", particiation.Fonction);
                db.Command.ExecuteNonQuery();

                db.Connection.Close();

            }
            catch 
            {

            }
        }

        public static void DeleteParticipation(int _Id)
        {
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "DeleteParticipation";
                
                db.Command.Parameters.AddWithValue("_Id", _Id);

                db.Command.ExecuteNonQuery();

                db.Connection.Close();
            }
            catch 
            {
               
            }
        }

        public static void UpdateParticipation(Participation participation)
        {
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "UpdateParticipation";
                db.Command.Parameters.AddWithValue("_Id", participation.Id);
                db.Command.Parameters.AddWithValue("_Matr", participation._Employe.Matr);
                db.Command.Parameters.AddWithValue("_CodeP", participation._Projet.CodeP);
                db.Command.Parameters.AddWithValue("_Fonction", participation.Fonction);
                db.Command.ExecuteNonQuery();

                db.Connection.Close();
            }
            catch 
            {

            }
        }
    }
}
