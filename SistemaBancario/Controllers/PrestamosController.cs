using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SistemaBancario.Controllers
{
    public class PrestamosController : Controller
    {
        public IActionResult ListaPrestamos()
        {
            return View();
        }
        
        public IActionResult SolicitarPrestamo()
        {
            return View();
        }
        public IActionResult EditarPrestamo()
        {
            return View();
        }
    }
}