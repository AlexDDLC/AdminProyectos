using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Models;
using System.Data.SqlClient;
using System.Data;

namespace SistemaBancario.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection ConexionDB = new SqlConnection("Data Source=DESKTOP-8ES98D2;Initial Catalog=CoopITLA;Integrated Security=True");
        SqlCommand ComandoSQL = new SqlCommand();
        SqlDataReader sqlRD;

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Verify(Account Acc)
        {
            ConexionDB.Open();
            ComandoSQL.CommandText = "";
            ComandoSQL.CommandType = CommandType.StoredProcedure;
            ComandoSQL.Parameters.AddWithValue("", Acc.Usuario);
            ComandoSQL.Parameters.AddWithValue("", Acc.Contrasena);
            sqlRD = ComandoSQL.ExecuteReader();
            if(sqlRD.Read())
            {
                ConexionDB.Close();
                return View("Dashboard");
            }
            else
            {
                ConexionDB.Close();
                return View();
            }
        }
    }
}