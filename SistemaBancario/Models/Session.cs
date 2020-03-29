using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancario.Models
{
    public interface ISession
    {
        public string usuario { get; set; }
        public string tipoUsuario { get; set; }
    }

}
