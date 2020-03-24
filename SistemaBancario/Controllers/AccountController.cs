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
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
       
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Data Source=.;Initial Catalog=CoopITLA;Integrated Security=True";

        }
        [HttpPost]

        public ActionResult Verify(Account Acc)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "EXEC LOGIN_CLIENTE '"+Acc.UsuarioCliente+"', '"+Acc.ContrasenaCliente+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("../Dashboard/Dashboard");
            }
            else
            {
               
                con.Close();
                return View("Login");
            }
            
           
        }
    }
}