using System;
using System.Reflection;
using System.Linq;
using MySql.Data.MySqlClient;
using projeto_mvc.Models;

namespace projeto_mvc.Services
{
    public static class DbSettings{
        public static bool startup { get; set; } = true;
        public static string ConnectionString { get{
            return "Server=localhost;Uid=root;Pwd=1234;";
        } }
        public static string DbName { get{
            return "ExampleDb";
        } }
    }
}