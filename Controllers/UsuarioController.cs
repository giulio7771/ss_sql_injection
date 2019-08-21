using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using projeto_mvc.Models;
using projeto_mvc.Services;
using System.Linq;
using MySql.Data.MySqlClient;

namespace projeto_mvc.Controllers
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logar(string login, string senha)
        {
            List<UsuarioViewModel> results;
            using (var context = new DbContext())
            {
                var command = new MySqlCommand($"SELECT * FROM USUARIO WHERE Login = '" + TratarInput(login) + "' AND Senha = '" + TratarInput(senha) + "'");

                results = context.GetCollection<UsuarioViewModel>(
                    command
                    );
            }
            if (results != null)
                ViewData["feedback"] = "login não efetuado com sucesso.";
            else
                ViewData["feedback"] = "login ou senha errado.";
            return View("login");
        }

        private string TratarInput(string input)
        {
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '\'':
                    case '\"':
                    case '\\':
                    case '%':
                    case '_':
                        result += '\\' + input[i];
                        break;
                    default:
                        result += input[i];
                        break;
                }
            }
            return result;
        }
    }
}