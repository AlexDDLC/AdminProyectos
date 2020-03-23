using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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