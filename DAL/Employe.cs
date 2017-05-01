using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Employe
    {

        #region properties
        [DisplayName("Matricule")]
        public int Matr { get; set; }
        [DisplayName("Nom employe")]
        public string NomE { get; set; }
        [DisplayName("Poste")]
        public string Poste { get; set; }
        [DisplayName("Date embauche")]
        public string DateEmb { get; set; }
        [DisplayName("Matricule Superieur")]
        public Employe Emp_Sup { get; set; }
        [DisplayName("Salaire")]
        public int Salaire { get; set; }
        [DisplayName("Comm")]
        public int Comm { get; set; }
        [DisplayName("Numero Departement")]
        public Departement _Departement { get; set; }
        #endregion

        public static List<Employe> Employes()
        {
            List<Employe> AllEmployes = new List<Employe>();
            
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "GetAllEmploye";

                MySqlDataReader reader = db.Command.ExecuteReader();
                while (reader.Read())
                {
                    Employe employe = new Employe();
                    if (reader.IsDBNull(0))
                        employe.Matr = -1;
                    else
                        employe.Matr = (int)reader["Matr"];
                    if (reader.IsDBNull(1))
                        employe.NomE = null;
                    else
                        employe.NomE = (string)reader["NomE"];
                    if (reader.IsDBNull(2))
                        employe.Poste = null;
                    else
                        employe.Poste = (string)reader["Poste"];
                    if (reader.IsDBNull(3))
                        employe.DateEmb = null;
                    else
                        employe.DateEmb = (string)reader["DateEmb"];
                    if (reader.IsDBNull(4))
                        employe.Emp_Sup = new Employe();
                    else
                    {
                        employe.Emp_Sup = new Employe();
                        employe.Emp_Sup = GetEmploye((int)reader["Sup"]);
                    }
                    if (reader.IsDBNull(5))
                        employe.Salaire = 0;
                    else
                        employe.Salaire = (int)reader["Salaire"];
                    if (reader.IsDBNull(6))
                        employe.Comm = 0;
                    else
                        employe.Comm = (int)reader["Comm"];
                    if (reader.IsDBNull(7))
                        employe._Departement = null;
                    else
                    {
                        employe._Departement = new Departement();
                        employe._Departement = Departement.GetDepartement((int)reader["NumDept"]);
                    }

                    AllEmployes.Add(employe);
                }

                db.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MyError :{ex.ToString()}");

            }
 

            return AllEmployes;
        }

        public static Employe GetEmploye(int id)
        {
            Employe employe = new Employe();
            try
            {

                DbConnect db = new DbConnect();
                db.Command.CommandText = "GetOneEmploye";
                db.Command.Parameters.AddWithValue("_Matr", id);
                MySqlDataReader reader = db.Command.ExecuteReader();
                reader.Read();
                if (reader.IsDBNull(0))
                    employe.Matr = -1;
                else
                    employe.Matr = (int)reader["Matr"];
                if (reader.IsDBNull(1))
                    employe.NomE = null;
                else
                    employe.NomE = (string)reader["NomE"];
                if (reader.IsDBNull(2))
                    employe.Poste = null;
                else
                    employe.Poste = (string)reader["Poste"];
                if (reader.IsDBNull(3))
                    employe.DateEmb = null;
                else
                    employe.DateEmb = (string)reader["DateEmb"];
                if (reader.IsDBNull(4))
                    employe.Emp_Sup = new Employe();
                else
                {
                    employe.Emp_Sup = new Employe();
                    employe.Emp_Sup = GetEmploye((int)reader["Sup"]);
                }
                if (reader.IsDBNull(5))
                    employe.Salaire = 0;
                else
                    employe.Salaire = (int)reader["Salaire"];
                if (reader.IsDBNull(6))
                    employe.Comm = 0;
                else
                    employe.Comm = (int)reader["Comm"];
                if (reader.IsDBNull(7))
                    employe._Departement = null;
                else
                {
                    employe._Departement = new Departement();
                    employe._Departement = Departement.GetDepartement((int)reader["NumDept"]);
                }

                db.Connection.Close();
            }
            catch
            {

            }
            return employe;
        }

        public static void DeleteEmploye(int id)
        {
            
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "DeleteEmploye";
                db.Command.Parameters.Add(new MySqlParameter("_Matr", id));
                db.Command.ExecuteNonQuery();
                db.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MyError {ex.ToString()}");
            }
        }

        public static void UpdateEmploye(Employe employe)
        {
            
            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "UpdateEmploye";
                db.Command.Parameters.Add(new MySqlParameter("_Matr", employe.Matr));
                db.Command.Parameters.Add(new MySqlParameter("_NomE", employe.NomE));
                db.Command.Parameters.Add(new MySqlParameter("_Poste", employe.Poste));
                db.Command.Parameters.Add(new MySqlParameter("_DateEmb", employe.DateEmb));
                db.Command.Parameters.Add(new MySqlParameter("_Sup", employe.Emp_Sup.Matr));
                db.Command.Parameters.Add(new MySqlParameter("_Salaire", employe.Salaire));
                db.Command.Parameters.Add(new MySqlParameter("_Comm", employe.Comm));
                db.Command.Parameters.Add(new MySqlParameter("_NumDept", employe._Departement.NumDept));
                db.Command.ExecuteNonQuery();
                db.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MyError {ex.ToString()}");
            } 
        }

        public static void InsertEmploye(Employe employe)
        {
            

            try
            {
                DbConnect db = new DbConnect();
                db.Command.CommandText = "InsertEmploye";
                db.Command.Parameters.Add(new MySqlParameter("_Matr", employe.Matr));
                db.Command.Parameters.Add(new MySqlParameter("_NomE", employe.NomE));
                db.Command.Parameters.Add(new MySqlParameter("_Poste", employe.Poste));
                db.Command.Parameters.Add(new MySqlParameter("_DateEmb", employe.DateEmb));
                if(employe.Emp_Sup.Matr == 0)
                    db.Command.Parameters.Add(new MySqlParameter("_Sup", null));
                else 
                    db.Command.Parameters.Add(new MySqlParameter("_Sup", employe.Emp_Sup.Matr));
                db.Command.Parameters.Add(new MySqlParameter("_Salaire", employe.Salaire));
                db.Command.Parameters.Add(new MySqlParameter("_Comm", employe.Comm));
                db.Command.Parameters.Add(new MySqlParameter("_NumDept", employe._Departement.NumDept));
                db.Command.ExecuteNonQuery();
                db.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"My Error : {ex.StackTrace.ToString()}");
            }      
        }

    }
}
