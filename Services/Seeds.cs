using System;
using System.Reflection;
using System.Linq;
using MySql.Data.MySqlClient;
using projeto_mvc.Models;

namespace projeto_mvc.Services
{
    public class Seeds{
        public Seeds()
        {
            new DbExecuter().Execute(new MySqlCommand(@"
                INSERT IGNORE INTO USUARIO
				SET Nome = 'default', 
                Login = 'user', 
                Senha ='123'
            "));
        }
    }
}