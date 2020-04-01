using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Models;

namespace SistemaBancario.Controllers
{
    public class PrestamosController : Controller
    {
        ConsultasSQLPrestamo conpres = new ConsultasSQLPrestamo();
        VariablesUser varuser = new VariablesUser();

        public IActionResult ListaSolicitudesPrestamos()
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

        public IActionResult EditarEstadoPrestamo(int idsol)
        {
            ListarSolicitudesPrestamo lsp = conpres.listarsolicitudPorID(idsol);
            return View(lsp);
        }

        [HttpPost]
        public IActionResult EditarEstadoPrestamo([Bind] ListarSolicitudesPrestamo lsp)
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

        public IActionResult SolicitarPrestamo()
        {
            return View();
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

        public IActionResult ListaPrestamosAprobados()
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