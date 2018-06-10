using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbConnect
    {
        public MySqlConnection Connection { get; set; }
        public MySqlCommand Command { get; set; }

        public DbConnect(string _ConnectionString = @"Server= 127.0.0.1; port=3306;Database=myschema;Uid=root;Pwd=root;")
        {
            Connection = new MySqlConnection();
            Connection.ConnectionString = _ConnectionString;
            Connection.Open();

            Command = new MySqlCommand();
            Command.Connection = Connection;
            Command.CommandType = System.Data.CommandType.StoredProcedure;
        }
    }
}
