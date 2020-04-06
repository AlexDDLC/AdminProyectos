using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Threading;

namespace SistemaBancario.Controllers
{
    public class PagosController : Controller
    {
        ConPagos conpagos = new ConPagos();
        VariablesUser varuser = new VariablesUser();

        public IActionResult ListarPagos()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return View("../Home/Index");
            }
            else
            {
                List<ListarPagos> listPagos = new List<ListarPagos>();
                if (HttpContext.Session.GetString("Roll") != "Cliente")
                {
                    listPagos = conpagos.listarPagos().ToList();
                }
                else
                {
                    listPagos = conpagos.listarsolicitudesCliente(varuser.cedula).ToList();
                }
                return View(listPagos);
            }
        }

        


    }


}

