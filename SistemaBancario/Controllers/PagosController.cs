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
        public IActionResult PagarPago(int idPag)
        {
            ListaPagos lsp = conPagos.listarPagosID(idPag);
            return View(lsp);
        }

        [HttpPost]
        public IActionResult PagarPago(int idPag, [Bind] ListaPagos lsp)
        {
            if (ModelState.IsValid)
            {
                if (lsp.PorPagar == "Aprobado")
                {
                    lsp.NuevoEstadoPago = "Aprobado";
                }
                else if (lsp.PorPagar == "Rechazar")
                {
                    lsp.NuevoEstadoPago = "Rechazado";
                }
                DateTime fecha = DateTime.Now;
                string formato = string.Format("{0:dd/MM/yyyy}", fecha);
                lsp.FechaPago = formato;
                conPagos.ActualizarPagos(lsp);
                return RedirectToAction("ListaSolicitudesPrestamos");
            }
            return View(conPagos);
        }

        public IActionResult ListaPagosPagados()
        {
            List<ListaPagos> listPagPa = new List<ListaPagos>();
            listPagPa = conPagos.ListaPagosPagados().ToList();
            return View(listPagPa);
        }

        public IActionResult ListaPagosSin()
        {
            List<ListaPagos> listPagSin = new List<ListaPagos>();
            listPagSin = conPagos.ListaPagosSin().ToList();
            return View(listPagSin);
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}