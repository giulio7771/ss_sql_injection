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
            connectionString = $"{DbSettings.ConnectionString}Database={DbSettings.DbName};";
        }
        public DbHelper()
        {
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