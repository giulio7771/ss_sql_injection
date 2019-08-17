using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projeto_mvc.Models;
using MySql.Data;
using MySql.Data.MySqlClient;

public class LoginController : Controller
{
    public LoginController()
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string login, string senha)
    {
        string result = "";
        string connetionString = "Server=localhost;DataBase=PeerOne;Uid=root;Pwd=1234";
        string query = @"SELECT Id FROM USUARIOS WHERE 
                Login='" + login + "' AND Senha='" + login + "'";
        var cnn = new MySqlConnection(connetionString);
        var command = new MySqlCommand(query, cnn);
        try
        {
            cnn.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result = reader.GetString("Id");
            }
        }
        finally
        {
            cnn.Close();
        }
        return Ok(result);
    }
}
