using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class SolicitudPrestamo
    {
        //Calcular amortuzacion
        public float monto { get; set; }
        public string tipoPrestamo { get; set; }
        public float plazos { get; set; }
        public float interes { get; set; }
        public float total { get; set; }
        public string calcular { get; set; }
        public List<SelectListItem> Tipo_Prestamo { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="Hipotecario", Text="Hipotecario"},
            new SelectListItem{Value="Extra crédito", Text="Extra crédito"},
            new SelectListItem{Value="Gerencial", Text="Gerencial"},
            new SelectListItem{Value="Salud", Text="Salud"},
            new SelectListItem{Value="Ordenes de compra", Text="Ordenes de compra"},
            new SelectListItem{Value="Resort", Text="Resort"}
        };

        //Crear solicitid de prestamo
        public string cedulaCliente { get; set; }
        public string estadoPrestamo { get; set; }
        public string tipoPrestamoSolicitado { get; set; }
        public float montoPrestamo { get; set; }
        public string detalles { get; set; }

        public DateTime fechaSolicitud { get; set; }
        public string solicitar { get; set; }
    }
}
