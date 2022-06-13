using Acudir.Infraestructure.Models;
using Acudir.Infraestructure.Services;
using Acudir.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acudir.Services.Services
{
    public class PersonaService : GenericService<Persona>, IPersonaService
    {

        private readonly AcudirContext _context;

        private readonly ILogger<PersonaService> _logger;

        public PersonaService(AcudirContext context, ILogger<PersonaService> logger) : base(context)
        {
            _context = context;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task DeletePersona(int id)
        {
            try{
                var persona =  await GetById(id);
                _context.Remove(persona);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ArgumentException("No se pudo borrar la persona", e);
            }
        }

        public async Task<Persona> GetPersonaAleatoria()
        {
            try
            {
                var result = await _context.Personas.OrderBy(o => Guid.NewGuid()).ToListAsync();
                return result.Where(r => r.Activo == true).FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new ArgumentException("No se pudo encontrar una persona", e);
            }
            
        }

        public async Task<Persona> GetById(int id)
        {
            try
            {
                return await _context.Personas.Where(x => x.ID == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                throw new ArgumentException("No se pudo encontrar a la persona", e);
            }
        }
    }
}
