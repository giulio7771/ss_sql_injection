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
            connectionString = "Server=localhost;DataBase=ExampleDb;Uid=root;Pwd=1234";
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