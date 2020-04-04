using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class ListarPagos
    {
        // Pagos
        public string ID_Pagos { get; set; }
        public string FK_ID_Cliente { get; set; }
        public string FK_ID_Prestamos { get; set; }
        public string FechaPago { get; set; }
        public string Monto { get; set; }
        public string Estado { get; set; }
        public string Restante { get; set; }
        public string CuotasCubiertas { get; set; }
        public string CuotasFaltantes { get; set; }

        // Sin Pagar
        public string ID_PagosPorPagar { get; set; }
        public string FK_ID_ClienteP { get; set; }
        public string FK_ID_PrestamosP { get; set; }
        public string FechaPagoP { get; set; }
        public string MontoP { get; set; }
        public string EstadoP { get; set; }
        public string RestanteP { get; set; }
        public string CuotasCubiertasP { get; set; }
        public string CuotasFaltantesP { get; set; }
    }
}
