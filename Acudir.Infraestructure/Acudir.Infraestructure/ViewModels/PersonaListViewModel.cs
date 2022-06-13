using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acudir.Infraestructure.ViewModels
{
    public class PersonaListViewModel
    {
        public PersonaListViewModel()
        {
            PersonasAnterioresList = new List<PersonaViewModel>();
        }

        public List<PersonaViewModel> PersonasAnterioresList { get; set; }

        public PersonaViewModel PersonaActual { get; set; }
    }
}
