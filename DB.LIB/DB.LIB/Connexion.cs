using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DB.LIB
{


    public class Connexion : IConnexion
    {
        private IDbConnection cnx;
        private IDbCommand cmd;

        public Connexion()
        {

            string server = "localhost";
            string database = "gestion_eleves";
            string username = "postgres";
            string password = "Imad2002";
            string port = "5432";


            string connectionString =
                $"Server={server};Port={port};Database={database};User Id={username};Password={password};";


            cnx = new Npgsql.NpgsqlConnection(connectionString);
        }

        public void Connect()
        {

            if (cnx.State != ConnectionState.Open)
                cnx.Open();

            cmd = cnx.CreateCommand();
        }

        public void Dispose()
        {
            if (cmd != null)
                cmd.Dispose();
            if (cnx != null && cnx.State == ConnectionState.Open)
                cnx.Close();
        }

        public int iud(string sql, Dictionary<string, object> parameters = null)
        {
            cmd.CommandText = sql;
            cmd.Parameters.Clear();


            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    IDbDataParameter dbParam = cmd.CreateParameter();
                    dbParam.ParameterName = param.Key;
                    dbParam.Value = param.Value ?? DBNull.Value;
                    cmd.Parameters.Add(dbParam);
                }
            }

            return cmd.ExecuteNonQuery();
        }

        public IDataReader select(string sql, Dictionary<string, object> parameters = null)
        {
            cmd.CommandText = sql;
            cmd.Parameters.Clear();

            // Ajout des paramètres à la commande
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    IDbDataParameter dbParam = cmd.CreateParameter();
                    dbParam.ParameterName = param.Key;
                    dbParam.Value = param.Value ?? DBNull.Value;
                    cmd.Parameters.Add(dbParam);
                }
            }

            return cmd.ExecuteReader();
        }
    }
}