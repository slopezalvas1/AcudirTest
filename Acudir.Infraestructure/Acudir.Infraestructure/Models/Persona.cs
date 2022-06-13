using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acudir.Infraestructure.Models
{
    public class Persona : Entity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Provincia { get; set; }
        public int Documento { get; set; }
        public int Telefono { get; set; }
        public bool Activo { get; set; }
        public string Mail { get; set; }

    }
}
