using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaBancario.Models
{
    public class ListaPagos
    {
        // Lista de Pagos
        public string ID_Pago { get; set; }
        public string FK_ID_Cliente { get; set; }
        public string FK_ID_Prestamos { get; set; }
        public string FechaPago { get; set; }
        public string Monto { get; set; }
        public string CuotasCubiertas { get; set; }
        public string CuotasFaltantes { get; set; }


        //Aprobar - Pago
        public string PorPagar { get; set; }
        public string NuevoEstadoPago { get; set; }
    }
}
