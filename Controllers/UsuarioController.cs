using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using projeto_mvc.Models;
using projeto_mvc.Services;
using System.Linq;

namespace projeto_mvc.Controllers
{
    public class UsuarioController : Controller
    {
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
                results = context.GetCollection<UsuarioViewModel>(
                    $"SELECT * FROM USUARIO WHERE Login = '{login}' AND Senha = '{senha}'"
                    );
            }
            if (results != null)
                ViewData["feedback"] = "login não efetuado com sucesso.";
            else
                ViewData["feedback"] = "login ou senha errado.";
            return View("login");
        }
    }
}