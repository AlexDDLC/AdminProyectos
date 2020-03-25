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
        public IActionResult ListaSolicitudesPrestamos()
        {
            return View();
        }

        public IActionResult SolicitarPrestamo()
        {
            //var tipo_prestamos = new SolicitudPrestamo();
            return View();
        }

        [HttpPost]
        public IActionResult SolicitarPrestamo([Bind] SolicitudPrestamo SPC)
        {
            //Calcular amortizacion
            float CA_monto = SPC.monto, CA_plazos = SPC.plazos, CA_interes = SPC.interes;
            string CA_tipoprestamo = SPC.tipoPrestamo;
            if(string.IsNullOrEmpty(CA_tipoprestamo))
            {

            }
            if(SPC.calcular == "Calcular")
            {
                SPC.total = (((CA_monto*(CA_interes/CA_plazos))/100) + (CA_monto/CA_plazos));
            }
            ViewData["total"] = SPC.total;

            //Crear solocitud prestamo
            SPC.estadoPrestamo = "Pendiente";
            SPC.fechaSolicitud = DateTime.Now;
            //SPC.fechaSolicitud.ToString("MM-dd-yyyy");
            string formato = string.Format("{0:dd/mm/yyyy}", SPC.fechaSolicitud);
            if (SPC.solicitar == "Solicitar")
            {
                if (ModelState.IsValid)
                {
                    conpres.CrearSolicitudPrestamo(SPC);
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