using Acudir.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acudir.Infraestructure.Services
{
    public interface IPersonaService
    {
        public Task<Persona> GetPersonaAleatoria();

        public Task DeletePersona(int id);
        public Task<Persona> GetById(int id);
    }
}
