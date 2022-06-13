using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Acudir.Infraestructure.ViewModels
{
    public class PersonaViewModel
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DisplayName("Nombre y Apellido")]
        public string NombreApellido => $"{this.Nombre} {this.Apellido}";
        public string Provincia { get; set; }
        public int Documento { get; set; }
        public int Telefono { get; set; }
        public string Mail { get; set; }
    }
}
