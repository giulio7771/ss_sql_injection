using System;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace projeto_mvc.Services
{
    public class DbService
    {
        public DbService()
        {
            EnsureCreated("ExampleDb");
        }

        public void EnsureCreated(string name)
        {
            new DbExecuter().Execute(new MySqlCommand(
                $"CREATE DATABASE IF NOT EXISTS {name};"
            ));
        }
    }
} 