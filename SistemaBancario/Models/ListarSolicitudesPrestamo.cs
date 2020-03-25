using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaBancario.Models
{
    public class ListarSolicitudesPrestamo
    {
        public int id { get; set; }
        public int solicitante { get; set; }
        public int cedula { get; set; }
        public int monto { get; set; }
        public int tipo { get; set; }
        public int fechasolicitud { get; set; }
        public int detalles { get; set; }
    }
}
