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

        public IActionResult EditarEstadoPago(int IDPag)
        {
            if (HttpContext.Session.GetString("Roll") != "Admin")
            {
                return View("../Home/Index");
            }
            else
            {
                ListarPagos lsp = conpagos.listarPagosPorID(IDPag);
                return View(lsp);
            }
        }
        [HttpPost]
        public IActionResult EditarEstadoPago(int IDPag, [Bind] ListarPagos lsp)
        {
            if (HttpContext.Session.GetString("Roll") != "Admin")
            {
                return View("../Home/Index");
            }
            else
            {
                DateTime fecha = DateTime.Now;
                string formato = string.Format("{0:dd/MM/yyyy}", fecha);
                lsp.FechaPago = formato;
                if (ModelState.IsValid)
                {
                    
                    if (lsp.accion == "Pagado")
                    {
                        lsp.NuevoEstadoPagos= "Pagado";
                        conpagos.ActualizarEstadoDePagoAprobado(lsp);
                        //Aqui abajo va el procedure

                    }
                    ModelState.Clear();
                    Thread.Sleep(2500);
                    return RedirectToAction("ListaSolicitudesPrestamos");
                }
                ModelState.Clear();
                Thread.Sleep(2500);
                return View(conpagos);
            }
        }

    }


}

