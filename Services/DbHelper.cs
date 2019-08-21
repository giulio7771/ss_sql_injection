using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace projeto_mvc.Services
{
    public class DbHelper : IDisposable
    {
        private MySqlConnection connection;
        private static string connectionString;

        static DbHelper()
        {
            connectionString = DbSettings.ConnectionString;
        }
        public DbHelper(bool useDatabase)
        {
            if (useDatabase)
                connection = new MySqlConnection($"{connectionString}Database={DbSettings.DbName};");
            else
                connection = new MySqlConnection(connectionString);
        }
        public void OpenConnection()
        {
            if (connection.State.ToString() == "Closed")
            {
                connection.Open();
            }
        }

        public void Dispose()
        {
            if (connection.State.ToString() == "Open")
            {
                connection.Close();
            }
        }

        public void Setup(MySqlCommand command)
        {
            command.Connection = connection;
            OpenConnection();
        }

    }
}