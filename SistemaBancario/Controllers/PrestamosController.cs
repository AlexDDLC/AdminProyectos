﻿using System;
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
        public IActionResult ListaSolicitudesPrestamos(ListarSolicitudesPrestamo LSP)
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