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
        public IActionResult ListaSolicitudesPrestamos()
        {
            return View();
        }

        public IActionResult SolicitarPrestamo()
        {
            var tipo_prestamos = new CalculadoraAmortizacion();
            return View(tipo_prestamos);
        }

        [HttpPost]
        public IActionResult SolicitarPrestamo(CalculadoraAmortizacion CalAm)
        {
            float CP_monto, CP_plazos, CP_interes;
            CP_monto = CalAm.monto;
            CP_plazos = CalAm.plazos;
            CP_interes = CalAm.interes;
            if(CalAm.calcular == "Calcular")
            {
                CalAm.total = (((CP_monto*(CP_interes/CP_plazos))/100) + (CP_monto/CP_plazos));
            }
            ViewData["total"] = CalAm.total; 
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