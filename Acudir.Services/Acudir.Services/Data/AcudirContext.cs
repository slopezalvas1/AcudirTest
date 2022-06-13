using Acudir.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acudir.Services.Data
{
    public class AcudirContext : DbContext
    {
        public AcudirContext()
        {
        }

        public AcudirContext(DbContextOptions<AcudirContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; }
    }
}
