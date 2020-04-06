using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public class ListarPagos
    {
        // Pagos
        public int IDPagos { get; set; }
        public string Cliente { get; set; }
        public string Prestamo { get; set; }
      // public string FK_Prestamo { get; set; }
        public string FechaPago { get; set; }
        public string Monto { get; set; }
        public string Estado { get; set; }
        public string Restante { get; set; }
        public string CuotasPagadas { get; set; }
        public string CuotasRestantes { get; set; }

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

        // Para las acciones

        public string accion { get; set; }
        public string NuevoEstadoPagos { get; set; }
        public float tasaInteres { get; set; }
        public int Cuotas { get; set; }
        public float CuotaMensual { get; set; }
    }
}
