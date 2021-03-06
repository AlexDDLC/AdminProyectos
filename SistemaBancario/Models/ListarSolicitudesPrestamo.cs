﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaBancario.Models
{
    public class ListarSolicitudesPrestamo
    {
        //Estas son las variables donde se guandan los datos

        //Listar prestamos
        public string id_sol { get; set; }
        public string solicitante { get; set; }
        public string cedula { get; set; }
        public string monto { get; set; }
        public string estado { get; set; }
        public string tipo { get; set; }
        public string fechasolicitud { get; set; }
        public string fechaRehazo { get; set; }
        public string detalles { get; set; }

        //Aprobar - rechazar prestamos
        public string accion { get; set; }
        public string NuevoEstadoPrestamo { get; set; }
        public float tasaInteres { get; set; }
        public int cuotas { get; set; }
        public float cuotaMensual { get; set; }
    }
}
