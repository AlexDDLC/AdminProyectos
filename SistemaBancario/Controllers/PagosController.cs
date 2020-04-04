using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaBancario.Models;

namespace SistemaBancario.Controllers
{
    public class PagosController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }


    }
}