using Acudir.Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acudir.Services.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AcudirContext context)
        {
            context.Database.EnsureCreated();

            if (context.Personas.Any())
            { return; }

            var personas = new Persona[] 
            {
                new Persona{Nombre="Steffanie", Apellido="Osterich", Documento=12345678, Mail="stefanie@osterich.com", Provincia="Buenos Aires", Telefono=11111111, Activo=true},
                new Persona{Nombre="Steffanie", Apellido="Osterich", Documento=23456781, Mail="stefanie@osterich.com", Provincia="Buenos Aires", Telefono=22222222, Activo=true},
                new Persona{Nombre="Steffanie", Apellido="Osterich", Documento=34567812, Mail="stefanie@osterich.com", Provincia="Buenos Aires", Telefono=33333333, Activo=true},
                new Persona{Nombre="Steffanie", Apellido="Osterich", Documento=45678123, Mail="stefanie@osterich.com", Provincia="Buenos Aires", Telefono=44444444, Activo=true},
                new Persona{Nombre="Steffanie", Apellido="Osterich", Documento=56781234, Mail="stefanie@osterich.com", Provincia="Buenos Aires", Telefono=55555555, Activo=true},
            };

            foreach (Persona p in personas)
            {
                context.Personas.Add(p);
            }
            context.SaveChanges();
        }

    }
}
