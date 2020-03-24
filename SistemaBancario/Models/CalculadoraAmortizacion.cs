using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class CalculadoraAmortizacion
    {
        public float monto { get; set; }
        public string tipoPrestamo { get; set; }
        public float plazos { get; set; }
        public float interes { get; set; }
        public float total { get; set; }
        public string calcular { get; set; }

        public List<SelectListItem> Tipo_Prestamo { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value="PH", Text="Hipotecario"},
            new SelectListItem{Value="EC", Text="Extra crédito"},
            new SelectListItem{Value="G", Text="Gerencial"},
            new SelectListItem{Value="S", Text="Salud"},
            new SelectListItem{Value="OC", Text="Ordenes de compra"},
            new SelectListItem{Value="R", Text="Resort"}
        };
    }
}
