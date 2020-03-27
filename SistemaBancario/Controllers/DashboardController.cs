using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SistemaBancario.Models;

namespace SistemaBancario.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard(Account acc)
        {
            return View();
        }
        public IActionResult IndexDashboard()
        {
           
            return View();
        }
    }
}