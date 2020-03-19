using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SistemaBancario.Models
{
    public class Account
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
}
