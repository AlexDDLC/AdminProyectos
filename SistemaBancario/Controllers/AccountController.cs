using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace SistemaBancario.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
       
        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        public IActionResult Login2()
        {

            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Data Source=sql5052.site4now.net;User ID=DB_A56E4E_CoopITLA_admin;Password=CoopITLA2020";

        }

        [HttpPost]
        public ActionResult Verify(Account Acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;

            if(Acc.UsuarioEmpleado == null)
            {
                com.CommandText = "EXEC LOGIN_CLIENTE '" + Acc.UsuarioCliente + "', '" + Acc.ContrasenaCliente + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {                  
                    con.Close();
                    return View("../Dashboard/Dashboard");
                }
                else
                {
                    ViewBag.Message = "Usuario y contraseña incorrectos. Por favor intente de nuevo.";

                    con.Close();
                    return View("Login");
                }
            }
            else
            {
                com.CommandText = "EXEC LOGIN_EMPLEADO '" + Acc.UsuarioEmpleado + "', '" + Acc.ContrasenaEmpleado + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    con.Close();
                    return View("../Dashboard/Dashboard");
                }
                else
                {
                    ViewBag.Message = "Usuario y contraseña incorrectos. Por favor intente de nuevo.";
                    con.Close();
                    return View("Login2");
                }
            }
        }
    }
}