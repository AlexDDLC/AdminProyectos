using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace SistemaBancario.Controllers
{
    public class PrestamosController : Controller
    {
        ConsultasSQLPrestamo conpres = new ConsultasSQLPrestamo();
        VariablesUser varuser = new VariablesUser();

        public IActionResult ListaSolicitudesPrestamos()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return View("../Home/Index");
            }
            else
            {
                List<ListarSolicitudesPrestamo> listsol = new List<ListarSolicitudesPrestamo>();
                if (varuser.roll != "Cliente")
                {
                    listsol = conpres.listarsolicitudes().ToList();
                }
                else
                {
                    listsol = conpres.listarsolicitudesCliente(varuser.cedula).ToList();
                }
                return View(listsol);
            }
        }

        public IActionResult EditarEstadoPrestamo(int idsol)
        {
            if (HttpContext.Session.GetString("Roll") != "Admin")
            {
                return View("../Home/Index");
            }
            else
            {
               
            ListarSolicitudesPrestamo lsp = conpres.listarsolicitudPorID(idsol);
            return View(lsp);
            }
        }

        [HttpPost]
        public IActionResult EditarEstadoPrestamo(int idsol, [Bind] ListarSolicitudesPrestamo lsp)
        {

            if (HttpContext.Session.GetString("Roll") != "Admin")
            {
                return View("../Home/Index");
            }
            else
            {

            DateTime fecha = DateTime.Now;
            string formato = string.Format("{0:dd/MM/yyyy}", fecha);
            lsp.fechaRehazo = formato;
            if (ModelState.IsValid)
            {
                if (lsp.accion == "Aprobar")
                {
                    lsp.NuevoEstadoPrestamo = "Aprobado";
                    conpres.ActualizarEstadoDePrestamoAprobado(lsp);
                }
                else if (lsp.accion == "Rechazar")
                {
                    lsp.NuevoEstadoPrestamo = "Rechazado";
                    conpres.ActualizarEstadoDePrestamoRechazado(lsp);
                }
                return RedirectToAction("ListaSolicitudesPrestamos");
            }
            return View(conpres);
              
            }
        }

        public IActionResult SolicitarPrestamo()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return View("../Home/Index");
            }
            else
            {
            return View();
            }
        }

        [HttpPost]
        public IActionResult SolicitarPrestamo([Bind] SolicitudPrestamo SPC)
        {
            if (!string.IsNullOrEmpty(SPC.calcular))
            {
                //Calcular amortizacion
                float CA_monto = SPC.monto, CA_plazos = SPC.plazos, CA_interes = SPC.interes;
                string CA_tipoprestamo = SPC.tipoPrestamo;
                if (!string.IsNullOrEmpty(CA_tipoprestamo))
                {
                    if (SPC.calcular == "Calcular")
                    {
                        SPC.total = (((CA_monto * (CA_interes / CA_plazos)) / 100) + (CA_monto / CA_plazos));
                    }
                    ViewData["total"] = SPC.total;
                }
            }
            else
            {
                //Crear solocitud prestamo
                DateTime fecha = DateTime.Now;
                string formato = string.Format("{0:dd/MM/yyyy}", fecha);
                SPC.estadoPrestamo = "Pendiente";
                SPC.fechaSolicitud = formato;

                if (SPC.solicitar == "Solicitar")
                {
                    if (ModelState.IsValid)
                    {
                        conpres.CrearSolicitudPrestamo(SPC);
                    }
                }
            }
            return View();
        }

        public IActionResult ListaPrestamosRechazados()
        {
            if (HttpContext.Session.GetString("Roll") != "Admin")
            {
                return View("../Home/Index");
            }
            else
            {

                List<ListarSolicitudesPrestamo> listsolRech = new List<ListarSolicitudesPrestamo>();
                if (varuser.roll != "Cliente")
                {
                    listsolRech = conpres.listarSolicitudesRechazadas().ToList();
                }
                else
                {
                    listsolRech = conpres.listarsolicitudesRechazadoCliente(varuser.cedula).ToList();
                }
                return View(listsolRech);
            }
        }

        public IActionResult ListaPrestamosAprobados()
        {
            if (HttpContext.Session.GetString("Roll") != "Admin")
            {
                return View("../Home/Index");
            }
            else
            {

                
                List<ListarSolicitudesPrestamo> listsolAprob = new List<ListarSolicitudesPrestamo>();
                if (varuser.roll != "Cliente")
                {
                    listsolAprob = conpres.listarSolicitudesAprobadas().ToList();
                }
                else
                {
                    listsolAprob = conpres.listarsolicitudesAprobadoCliente(varuser.cedula).ToList();
                }
                return View(listsolAprob);
            }
        }
    }
}