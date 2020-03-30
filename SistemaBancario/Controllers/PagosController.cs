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
        ConPagos conPagos = new ConPagos();
        public IActionResult ListarPagos()
        {
            List<ListaPagos> ListPagos = new List<ListaPagos>();
            ListPagos = conPagos.listarPagos().ToList();
            return View(ListPagos);
        }
        public IActionResult PagarPago(int idsol)
        {
            ListaPagos lsp = ConPagos.ListaPagosID(idsol);
            return View(lsp);
        }

        [HttpPost]
        public IActionResult PagarPago(int idsol, [Bind] ListaPagos lsp)
        {
            if (ModelState.IsValid)
            {
                if (lsp.accion == "Pagar")
                {
                    lsp.NuevoEstadoPrestamo = "Aprobado";
                }
                else if (lsp.accion == "Rechazar")
                {
                    lsp.NuevoEstadoPrestamo = "Rechazado";
                }
                DateTime fecha = DateTime.Now;
                string formato = string.Format("{0:dd/MM/yyyy}", fecha);
                lsp.fechaRehazo = formato;
                conpres.ActualizarEstadoDePrestamo(lsp);
                return RedirectToAction("ListaSolicitudesPrestamos");
            }
            return View(conpres);
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}