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
        ListarSolicitudesPrestamo listpres = new ListarSolicitudesPrestamo();
        List<ListarSolicitudesPrestamo> listsol = new List<ListarSolicitudesPrestamo>();

        public IActionResult ListaSolicitudesPrestamos()
        {
            listsol = conpres.listarsolicitudes().ToList();
            return View(listsol);
        }

        [HttpPost]
        public IActionResult EditarEstadoPrestamo(int? idsol)
        {
            if(idsol == null)
            {
                return NotFound(); 
            }
            ListarSolicitudesPrestamo lsp = conpres.listarsolicitudPorID(idsol);
            if(lsp == null)
            {
                return NotFound();
            }
            return View(lsp);
        }

        [HttpPost]
        public IActionResult EditarEstadoPrestamo(int? idsol, [Bind] ListarSolicitudesPrestamo lispres)
        {
            if (idsol == null)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                conpres.EditarEstadoDePrestamo(lispres);
                return RedirectToAction("");
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
            return View();
        }

        public IActionResult ListaPrestamosAprobados()
        {
            return View();
        }
    }
}