using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using projeto_mvc.Models;
using System.Data;
using System.Data.SqlClient;

namespace projeto_mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
          string connectionString = "Server=172.17.0.2;Database=exe1;Uid=root;Pwd=root;";
          using (SqlConnection connection = new SqlConnection(connectionString))
          {
            string sql = $"QUERY";
		        using (SqlCommand command = new SqlCommand(sql, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        return View();
  }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
