﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;


namespace SistemaBancario.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        VariablesUser varUser = new VariablesUser();
        SqlDataReader dr;

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                return View("../Home/Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login2()
        {
            if (HttpContext.Session.GetString("Usuario") != null)
            {
                return View("../Home/Index");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Inactivo()
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

            if (Acc.UsuarioEmpleado == null)
            {
                com.CommandText = "EXEC LOGIN_CLIENTE '" + Acc.UsuarioCliente + "', '" + Acc.ContrasenaCliente + "'";
                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    HttpContext.Session.SetString("Usuario", Acc.UsuarioCliente);
                    HttpContext.Session.SetString("Roll", "Cliente");

                    con.Close();

                    verificarEstatus(Acc.UsuarioCliente, "CLIENTES");

                    if (HttpContext.Session.GetString("Estatus") == "Activo")
                    {
                        infoClienteUser(Acc.UsuarioCliente);
                        return View("../Dashboard/Dashboard");
                    }
                    else
                    {
                        HttpContext.Session.Remove("Usuario");
                        HttpContext.Session.Remove("Roll");

                        con.Close();
                        return View("Inactivo");
                    }
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
                    HttpContext.Session.SetString("Usuario", Acc.UsuarioEmpleado);
                    HttpContext.Session.SetString("Roll", "Admin");

                    con.Close();

                    verificarEstatus(Acc.UsuarioEmpleado,"EMPLEADOS");

                    if (HttpContext.Session.GetString("Estatus") == "Activo")
                    {
                        infoEmpleadoUser(Acc.UsuarioEmpleado);
                        return View("../Dashboard/Dashboard");
                    }
                    else
                    {
                        HttpContext.Session.Remove("Usuario");
                        HttpContext.Session.Remove("Roll");

                        con.Close();
                        return View("Inactivo");
                    }
                }
                else
                {
                    ViewBag.Message = "Usuario y contraseña incorrectos. Por favor intente de nuevo.";
                    con.Close();
                    return View("Login2");
                }
            }
        }

        public void Logout()
        {
            HttpContext.Session.Remove("Usuario");

            HttpContext.Session.SetString("ID", "");
            HttpContext.Session.SetString("Cedula", "");
            varUser.cedula = "";
            varUser.roll = "";
            HttpContext.Session.SetString("Nombre", "");
            HttpContext.Session.SetString("Apellido", "");
            HttpContext.Session.SetString("cuentaBancaria", "");
            HttpContext.Session.Remove("Roll");

            Response.Redirect("../Home/Index");
        }

        /*Verificar status de cuenta*/
        public void verificarEstatus(string usuario, string tipo)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM "+tipo+" where Usuario = '" + usuario + "'";
            dr = com.ExecuteReader();

            while (dr.Read())
            {
                HttpContext.Session.SetString("Estatus", dr["Estatus"].ToString());
            }
            con.Close();
        }

        /* SELECT INFO DE CLIENTE BY user*/
        public void infoClienteUser(string user)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM CLIENTES where Usuario = '" + user + "'";
            dr = com.ExecuteReader();

            while (dr.Read())
            {
                HttpContext.Session.SetString("ID", dr["ID_Cliente"].ToString());
                HttpContext.Session.SetString("Cedula", dr["Cedula"].ToString());
                varUser.cedula = dr["Cedula"].ToString();
                varUser.roll = "Cliente";
                HttpContext.Session.SetString("Nombre", dr["Nombre"].ToString());
                HttpContext.Session.SetString("Apellido", dr["Apellido"].ToString());
                HttpContext.Session.SetString("cuentaBancaria", dr["cuentaBancaria"].ToString());
            }
            con.Close();
        }

        /* SELECT INFO DE Empleado BY user*/
        public void infoEmpleadoUser(string user)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "SELECT * FROM EMPLEADOS where Usuario = '" + user + "'";
            dr = com.ExecuteReader();

            while (dr.Read())
            {
                HttpContext.Session.SetString("ID", dr["ID_Empleado"].ToString());
                HttpContext.Session.SetString("Cedula", dr["Cedula"].ToString());
                varUser.cedula = dr["Cedula"].ToString();
                varUser.roll = "Empleado";
                HttpContext.Session.SetString("Nombre", dr["Nombre"].ToString());
                HttpContext.Session.SetString("Apellido", dr["Apellido"].ToString());
                HttpContext.Session.SetString("cuentaBancaria", dr["cuentaBancaria"].ToString());
            }
            con.Close();
        }
    }
}