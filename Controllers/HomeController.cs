using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projeto_mvc.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using projeto_mvc.Services;
using projeto_mvc.Models;

namespace projeto_mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult visualizar(){
            List<UsuarioViewModel> result;

                using(var context = new DbContext<UsuarioViewModel>())
                {
                    result = context.Select("SELECT * FROM USUARIOS");
                }
            return View(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
